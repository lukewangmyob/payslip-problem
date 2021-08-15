using payslip_problem_luke.util;
using PaySlipProblem.service;

namespace PaySlipProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleUtils = new ConsoleUtils();
            var consoleReader = new ConsoleReader(consoleUtils);
            var employeeDetailsReader = new EmployeeDetailsReader(consoleReader);

            var employeeDetails = employeeDetailsReader.Read();
            var payslip = PaySlipGenerator.Generate(employeeDetails);
            
            consoleUtils.Write("\nYour payslip has been generated:\n");
            consoleUtils.Write(payslip.output());
            consoleUtils.Write("\nThank you for using MYOB!");
        }
    }
}
