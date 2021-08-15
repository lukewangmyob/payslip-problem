using payslip_problem_luke.model;
using payslip_problem_luke.util;

namespace payslip_problem_luke.service
{
    public class EmployeeDetailsReader
    {
        private readonly ConsoleUtils _consoleUtils;

        public EmployeeDetailsReader(ConsoleUtils consoleUtils)
        {
            _consoleUtils = consoleUtils;
        }

        public EmployeeDetails Read()
        {
            var firstName = _consoleUtils.ReadString();
            return null;
        }
    }
}