using System;
using System.IO;
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
            return (string) Read("string", fieldName);
        }

        public int ReadInt(string fieldName)
        {
            return (int) Read("int", fieldName);
        }

        private object Read(string type, string fieldName) {
            while (true) {
                _consoleUtils.Write($"{UserInputPrefix} {fieldName}");
                var userInput = _consoleUtils.Read();
                if (userInput == QuitFlag) {
                    throw new QuitApplicationException("User chose to quit");
                }

                try {
                    switch (type) {
                        case "int":
                            return int.Parse(userInput);
                        case "string":
                            return parseString(userInput);
                    }
                } catch (Exception e) {
                    _consoleUtils.Write($"{InvalidInputErrorMessage}, error: {e.Message}");
                }
            }
        }

        private string parseString(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
            {
                throw new InvalidDataException("String can not be blank");
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