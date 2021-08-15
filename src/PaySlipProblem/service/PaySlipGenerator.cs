using System;
using System.Collections.Generic;
using System.Linq;
using PaySlipProblem.model;

namespace PaySlipProblem.service
{
    public static class PaySlipGenerator
    {
        private static readonly List<TaxConfig> IncomeTaxConfigs = new()
        {
            new TaxConfig(0, 18200, 0,0),
            new TaxConfig(18201, 37000, 0.19, 0),
            new TaxConfig(37001, 87000, 0.325, 3572),
            new TaxConfig(87001,180000, 0.37, 19822),
            new TaxConfig(180000, int.MaxValue, 0.45, 54232)
        };

        public static PaySlip Generate(EmployeeDetails employeeDetails)
        {
            var annualSalary = employeeDetails.AnnualSalary;
            var grossIncome = Math.Floor(annualSalary / 12);
            var incomeTax = Math.Ceiling(CalculateIncomeTax(annualSalary));
            var netIncome = grossIncome - incomeTax;
            var super = Math.Floor(grossIncome * employeeDetails.SuperRate / 100);
            var name = $"{employeeDetails.FirstName} {employeeDetails.LastName}";

            return new PaySlip(name, employeeDetails.StartDate, employeeDetails.EndDate, grossIncome, incomeTax,
                netIncome, super);
        }

        private static double CalculateIncomeTax(double annualSalary)
        {
            return (
                from taxConfig in IncomeTaxConfigs 
                where annualSalary >= taxConfig.LowerLimit && annualSalary <= taxConfig.UpperLimit 
                select (taxConfig.Amount + (annualSalary - taxConfig.LowerLimit) * taxConfig.Rate) / 12
            ).FirstOrDefault();
        }
    }
}