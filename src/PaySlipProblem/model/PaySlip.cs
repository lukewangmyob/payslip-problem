using System;

namespace PaySlipProblem.model
{
    public class PaySlip
    {
        private string Name { get; }
        private DateTime StartDate { get; }
        private DateTime EndDate { get; }
        private double GrossIncome { get; }
        private double IncomeTax { get; }
        private double Super { get; }

        public PaySlip(string name, DateTime startDate, DateTime endDate, double grossIncome, double incomeTax, double super)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            GrossIncome = grossIncome;
            IncomeTax = incomeTax;
            Super = super;
        }
    }
}