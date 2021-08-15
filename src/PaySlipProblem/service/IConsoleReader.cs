using System;

namespace PaySlipProblem.service
{
    public interface IConsoleReader
    {
        public double ReadDouble(string fieldName);
        public string ReadString(string fieldName);
        public DateTime ReadDate(string fieldName);
    }
}