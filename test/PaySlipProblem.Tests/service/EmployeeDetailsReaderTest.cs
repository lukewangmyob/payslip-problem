using System;
using Moq;
using PaySlipProblem.model;
using PaySlipProblem.service;
using Xunit;

namespace PaySlipProblem.Tests.service
{
    public class EmployeeDetailsReaderTest
    {
        private const string FirstName = "James";
        private const string SurName = "Bond";
        private const double AnnualSalary = 50000;
        private const double SuperRate = 9.5;
        private static readonly DateTime StartDate = new(2001, 3, 1);
        private static readonly DateTime EndDate = new(2001, 3, 31);
        
        [Fact]
        public void ShouldParseConsoleInputToCorrectEmployeeDetails()
        {
            var consoleReader = new Mock<IConsoleReader>();
            var employeeDetailsReader = new EmployeeDetailsReader(consoleReader.Object);
            
            consoleReader.Setup(c => c.ReadString("name")).Returns(FirstName);
            consoleReader.Setup(c => c.ReadString("surname")).Returns(SurName);
            consoleReader.Setup(c => c.ReadDouble("annual salary")).Returns(AnnualSalary);
            consoleReader.Setup(c => c.ReadDouble("super rate")).Returns(SuperRate);
            consoleReader.Setup(c => c.ReadDate("start date")).Returns(StartDate);
            consoleReader.Setup(c => c.ReadDate("end date")).Returns(EndDate);
            
            var expectedEmployeeDetails =
                new EmployeeDetails(FirstName, SurName, AnnualSalary, SuperRate, StartDate, EndDate);
            
            // when
            var employeeDetails = employeeDetailsReader.Read();
        
            // then
            Assert.Equal(expectedEmployeeDetails, employeeDetails);
        }
    }
}