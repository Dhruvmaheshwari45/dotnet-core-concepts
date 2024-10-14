using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DITestLibrary
{
    public abstract class CBase
    {
        public CBase() { }
        protected abstract void do_job();
        public void DoJob()
        {
            Console.WriteLine("Bussiness Started");
            do_job();
            Console.WriteLine("Bussiness completed");
        }
    }
}
