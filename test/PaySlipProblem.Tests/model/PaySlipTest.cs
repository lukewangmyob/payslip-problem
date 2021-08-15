using System;
using payslip_problem_luke.model;
using PaySlipProblem.model;
using PaySlipProblem.service;
using Xunit;

namespace PaySlipProblem.Tests.model
{
    public class PaySlipTest
    {
        
        private const string Name = "John Doe";
        private const int GrossIncome = 5004;
        private const int IncomeTax = 922;
        private const int NetIncome = 4082;
        private const int Super = 450;
        private static readonly DateTime StartDate = new(2001, 3, 1);
        private static readonly DateTime EndDate = new(2001, 3, 31);
        
        [Fact]
        public void ShouldGenerateCorrectPaySlip()
        {
            // given
            var paySlip = new PaySlip(Name, StartDate, EndDate, GrossIncome, IncomeTax, NetIncome, Super);
            var expectedPaySlipOutput =
                "Name: John Doe\nPay Period: 01 March - 31 March\nGross Income: 5004\nIncome Tax: 922\nNet Income:4082\nSuper: 450";
            
            // when
            var paySlipOutput = paySlip.output();
        
            // then
            Assert.Equal(expectedPaySlipOutput, paySlipOutput);
        }
    }
}