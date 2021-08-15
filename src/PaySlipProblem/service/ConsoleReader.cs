using System;
using payslip_problem_luke.util;

namespace PaySlipProblem.service
{
    public class ConsoleReader
    {
        private readonly ConsoleUtils _consoleUtils;
        private const string QuitFlag = "quit";
        private const string UserInputPrefix = "Please input your";
        private const string InvalidInputErrorMessage = "Please enter valid input";
        
        public ConsoleReader(ConsoleUtils consoleUtils)
        {
            _consoleUtils = consoleUtils;
        }

        public string ReadString(string fieldName)
        {
            var isValid = false;
            var userInput = "";
            
            while (!isValid)
            {
                _consoleUtils.Write($"{UserInputPrefix} {fieldName}");
                userInput = _consoleUtils.Read();
                if (userInput == QuitFlag)
                {
                    throw new QuitApplicationException("User chose to quit");
                }
            
                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    _consoleUtils.Write(InvalidInputErrorMessage);
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