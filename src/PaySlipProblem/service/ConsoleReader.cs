using System;
using System.IO;
using payslip_problem_luke.util;

namespace PaySlipProblem.service
{
    public class ConsoleReader
    {
        private readonly ConsoleUtils _consoleUtils;
        public ConsoleReader(ConsoleUtils consoleUtils)
        {
            _consoleUtils = consoleUtils;
        }

        public string ReadString()
        {
            var value = _consoleUtils.Read();
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidDataException();
            }
            
            return _consoleUtils.Read();
        }
    }
    
}