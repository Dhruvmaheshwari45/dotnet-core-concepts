using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacLibrary
{
    public interface IClient
    {
        void Job();
    }
    public delegate void FPTR();
    public class Vendor
    {
        public void DoBusiness(IClient iclient)
        {
            Console.WriteLine("Vendor: Task1");
            iclient.Job();
            Console.WriteLine("Vendor: Task3");
        }
        public void DoBusiness(FPTR fptr)
        {
            Console.WriteLine("Vendor: Task1");
            //task1 client
            fptr(); //client task
            //task2 client
            Console.WriteLine("Vendor: Task3");
            Console.WriteLine(new string('_', 50));
        }
    }
}
