using PaySlipProblem.service;
using PaySlipProblem.util;

namespace PaySlipProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleUtils = new ConsoleUtils();
            var consoleReader = new ConsoleReader(consoleUtils);
            
            try
            {
                var employeeDetailsReader = new EmployeeDetailsReader(consoleReader);
                var employeeDetails = employeeDetailsReader.Read();
                var payslip = PaySlipGenerator.Generate(employeeDetails);
            
                consoleUtils.Write("\nYour payslip has been generated:\n");
                consoleUtils.Write(payslip.Output());
                consoleUtils.Write("\nThank you for using MYOB!");
            }
            catch (QuitApplicationException exception)
            {
                consoleUtils.Write("Application has exited successfully");
            }
        }
    }
}
