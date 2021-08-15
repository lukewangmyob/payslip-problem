using System;

namespace PaySlipProblem.util
{
    public class ConsoleUtils
    {
        public virtual string Read()
        {
            return Console.ReadLine();
        }
        
        public virtual void Write(string s)
        {
            Console.WriteLine(s);
        }
    }
}