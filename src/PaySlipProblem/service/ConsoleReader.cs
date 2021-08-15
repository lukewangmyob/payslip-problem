using System;
using System.IO;
using payslip_problem_luke.util;

namespace PaySlipProblem.service
{
    public class ConsoleReader: IConsoleReader
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
            return (string) GenericRead("string", fieldName);
        }

        public int ReadInt(string fieldName)
        {
            return (int) GenericRead("int", fieldName);
        }
        
        public double ReadDouble(string fieldName)
        {
            return (double) GenericRead("double", fieldName);
        }

        public DateTime ReadDate(string fieldName)
        {
            return (DateTime) GenericRead("date", fieldName);
        }

        private object GenericRead(string type, string fieldName) {
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
                        case "double":
                            return double.Parse(userInput);
                        case "string":
                            return parseString(userInput);
                        case "date":
                            return DateTime.Parse(userInput);
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