using System;
using System.IO;
using payslip_problem_luke.util;

namespace PaySlipProblem.service
{
    public class ConsoleReader
    {
        private readonly ConsoleUtils _consoleUtils;
        private const string QUIT_FLAG = "quit";
        public ConsoleReader(ConsoleUtils consoleUtils)
        {
            _consoleUtils = consoleUtils;
        }

        public string ReadString()
        {
            var isValid = false;
            var userInput = "";
            
            while (!isValid)
            {
                userInput = _consoleUtils.Read();
                if (userInput == QUIT_FLAG)
                {
                    throw new QuitApplicationException("User choose to quit");
                }
            
                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    isValid = true;
                }
            }
            
            return userInput;
        }
    }
    
    public class QuitApplicationException: Exception
    {
        public QuitApplicationException(string message)
        {
        }
    }
}