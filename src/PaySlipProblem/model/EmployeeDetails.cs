using System;

namespace payslip_problem_luke.model
{
    public class EmployeeDetails
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int AnnualSalary { get; }
        public double SuperRate { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public EmployeeDetails(string firstName, string lastName, int annualSalary, double superRate, DateTime startDate, DateTime endDate)
        {
            FirstName = firstName;
            LastName = lastName;
            AnnualSalary = annualSalary;
            SuperRate = superRate;
            StartDate = startDate;
            EndDate = endDate;
        }

        protected bool Equals(EmployeeDetails other)
        {
            return FirstName == other.FirstName && LastName == other.LastName && AnnualSalary == other.AnnualSalary && SuperRate.Equals(other.SuperRate) && StartDate.Equals(other.StartDate) && EndDate.Equals(other.EndDate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((EmployeeDetails) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, AnnualSalary, SuperRate, StartDate, EndDate);
        }
    }
}