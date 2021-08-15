namespace PaySlipProblem.model
{
    public class TaxConfig
    {
        public int LowerLimit { get; }
        public int UpperLimit { get; }
        public double Rate { get; }
        public int Amount { get; }

        public TaxConfig(int lowerLimit, int upperLimit, double rate, int amount)
        {
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
            Rate = rate;
            Amount = amount;
        }
    }
}