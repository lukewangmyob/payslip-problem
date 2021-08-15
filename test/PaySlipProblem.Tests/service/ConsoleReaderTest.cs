using Moq;
using payslip_problem_luke.util;
using PaySlipProblem.service;
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
        public void ShouldReadStringValueCorrectly()
        {
            // given
            _consoleUtils.Setup(c => c.Read()).Returns("James");
            const string expectedValue = "James";
            
            // when
            var value = _subject.ReadString();
            
            // then
            Assert.Equal(expectedValue, value);
        }
    }
}