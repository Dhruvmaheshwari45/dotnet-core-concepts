using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDay1
{
    abstract class Account
    {
        protected abstract void ActualJob();
        public void Job()
        {
            Console.WriteLine("Open DB");
            ActualJob();
            Console.WriteLine("Close DB");
            Console.WriteLine(new string('_', 40));
        }
    }
    class Savings : Account
    {
        protected override void ActualJob()
        {
            Console.WriteLine("Saving Job");
        }
    }
    class Current: Account
    {
        protected override void ActualJob()
        {
            Console.WriteLine("Current Job");
        }
    }
    class Program3
    {
        static void Main(string[] args)
        {
            Savings savings = new Savings();
            Current current = new Current();

            savings.Job();
            current.Job();
        }
    }
}
