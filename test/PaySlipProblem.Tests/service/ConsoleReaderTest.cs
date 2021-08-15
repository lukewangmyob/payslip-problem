using System;
using Moq;
using PaySlipProblem.service;
using PaySlipProblem.util;
using Xunit;

namespace PaySlipProblem.Tests.service
{
    public class ConsoleReaderTest
    {
        private readonly ConsoleReader _subject;
        private readonly Mock<ConsoleUtils> _consoleUtils;

        public ConsoleReaderTest()
        {
            _consoleUtils = new Mock<ConsoleUtils>();
            _subject = new ConsoleReader(_consoleUtils.Object);
        }

        [Fact]
        public void ReadStringShouldReadStringValueCorrectly()
        {
            // given
            _consoleUtils.Setup(c => c.Read()).Returns("James");
            
            // when
            var value = _subject.ReadString("name");
            
            // then
            Assert.Equal("James", value);
        }
        
        [Fact]
        public void ReadStringShouldKeepAskingUserIfStringIsBlankOrEmpty()
        {
            // given
            _consoleUtils.SetupSequence(c => c.Read())
                .Returns("  ")
                .Returns("")
                .Returns("James");
            
            // when
            var value = _subject.ReadString("name");
            
            // then
            Assert.Equal("James", value);
        }

        [Fact]
        public void ReadStringShouldThrowExceptionWhenUserTryToQuit()
        {
            // given
            _consoleUtils.Setup(c => c.Read()).Returns("quit");
            const string expectedValue = "James";
            
            // then
            Assert.Throws<QuitApplicationException>(
                // when
                () => _subject.ReadString("name")
            );
        }

        [Fact]
        public void ReadDoubleShouldThrowExceptionWhenUserTryToQuit()
        {
            // given
            _consoleUtils.SetupSequence(c => c.Read())
                .Returns("  ")
                .Returns("quit");
            
            // then
            Assert.Throws<QuitApplicationException>(
                // when
                () => _subject.ReadDouble("super rate")
            );
        }

        [Fact]
        public void ReadDoubleShouldKeepAskingUserIfInputIsNotValid()
        {
            // given
            _consoleUtils.SetupSequence(c => c.Read())
                .Returns("  ")
                .Returns("")
                .Returns("James")
                .Returns("12.5");
            
            // when
            var value = _subject.ReadDouble("super rate");
            
            // then
            Assert.Equal(12.5, value);
        }

        [Fact]
        public void ReadDateShouldThrowExceptionWhenUserTryToQuit()
        {
            // given
            _consoleUtils.SetupSequence(c => c.Read())
                .Returns("  ")
                .Returns("quit");
            
            // then
            Assert.Throws<QuitApplicationException>(
                // when
                () => _subject.ReadDate("start date")
            );
        }

        [Fact]
        public void ReadDateShouldKeepAskingUserIfInputIsNotInteger()
        {
            // given
            _consoleUtils.SetupSequence(c => c.Read())
                .Returns("  ")
                .Returns("")
                .Returns("James")
                .Returns("1 March");
            
            // when
            var value = _subject.ReadDate("super rate");
            
            // then
            Assert.Equal(new DateTime(2001, 3,1), value);
        }
    }
}