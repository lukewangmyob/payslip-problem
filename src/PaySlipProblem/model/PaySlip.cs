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
        private double NetIncome { get; }
        private double Super { get; }

        public PaySlip(string name, DateTime startDate, DateTime endDate, double grossIncome, double incomeTax, double netIncome, double super)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            GrossIncome = grossIncome;
            IncomeTax = incomeTax;
            NetIncome = netIncome;
            Super = super;
        }

        protected bool Equals(PaySlip other)
        {
            return Name == other.Name && StartDate.Equals(other.StartDate) && EndDate.Equals(other.EndDate) && GrossIncome.Equals(other.GrossIncome) && IncomeTax.Equals(other.IncomeTax) && NetIncome.Equals(other.NetIncome) && Super.Equals(other.Super);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PaySlip) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, StartDate, EndDate, GrossIncome, IncomeTax, NetIncome, Super);
        }

        public string Output()
        {
            return $"Name: {Name}\nPay Period: {StartDate:dd MMMM} - {EndDate:dd MMMM}\nGross Income: {GrossIncome}\nIncome Tax: {IncomeTax}\nNet Income:{NetIncome}\nSuper: {Super}";
        }
    }
}