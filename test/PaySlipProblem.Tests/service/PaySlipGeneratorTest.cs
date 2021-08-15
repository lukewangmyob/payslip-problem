using System;
using PaySlipProblem.model;
using PaySlipProblem.service;
using Xunit;

namespace PaySlipProblem.Tests.service
{
    public class PaySlipGeneratorTest
    {
        private const string Name = "John Doe";
        private const string FirstName = "John";
        private const string SurName = "Doe";
        private const int AnnualSalary = 60050;
        private const int GrossIncome = 5004;
        private const int IncomeTax = 922;
        private const int NetIncome = 4082;
        private const int Super = 450;
        private const double SuperRate = 9;
        private static readonly DateTime StartDate = new(2001, 3, 1);
        private static readonly DateTime EndDate = new(2001, 3, 31);
        
        [Fact]
        public void ShouldGenerateCorrectPaySlip()
        {
            // given
            var expectedPaySlip = new PaySlip(Name, StartDate, EndDate, GrossIncome, IncomeTax, NetIncome, Super);
            var employeeDetails = new EmployeeDetails(FirstName, SurName, AnnualSalary, SuperRate, StartDate, EndDate);
            
            // when
            var paySlip = PaySlipGenerator.Generate(employeeDetails);
        
            // then
            Assert.Equal(expectedPaySlip, paySlip);
        }
    }
}