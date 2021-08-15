using payslip_problem_luke.model;

namespace PaySlipProblem.service
{
    public class EmployeeDetailsReader
    {
        private readonly IConsoleReader _consoleReader;

        public EmployeeDetailsReader(IConsoleReader consoleReader)
        {
            _consoleReader = consoleReader;
        }

        public EmployeeDetails Read()
        {
            return new EmployeeDetails(
                _consoleReader.ReadString("name"),
                _consoleReader.ReadString("surname"),
                _consoleReader.ReadDouble("annual salary"),
                _consoleReader.ReadDouble("super rate"),
                _consoleReader.ReadDate("start date"),
                _consoleReader.ReadDate("end date")
            );
        }
    }
}