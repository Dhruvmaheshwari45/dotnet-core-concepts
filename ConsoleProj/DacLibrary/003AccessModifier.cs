using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacLibraryAccessModifier
{
    public class CA
    {
        private int pvt = 10;
        protected int prot = 20;
        public int pub = 30;
        internal int inter = 40;
        protected internal int protInt = 50;

        public void DisplayCA()
        {
            Console.WriteLine($"pvt        : {pvt}");
            Console.WriteLine($"prot       : {prot}");
            Console.WriteLine($"pub        : {pub}");
            Console.WriteLine($"inter      : {inter}");
            Console.WriteLine($"protInt    : {protInt}");
        }
    }

    public class CB : CA
    {
        public void DisplayCB()
        {
            // Console.WriteLine($"pvt        : {pvt}"); // Error
            Console.WriteLine($"prot       : {prot}");
            Console.WriteLine($"pub        : {pub}");
            Console.WriteLine($"inter      : {inter}");
            Console.WriteLine($"protInt    : {protInt}");
        }
    }

    public class ContainCA
    {
        public void DisplayContain()
        {
            CA obj = new CA();
            //Console.WriteLine($"pvt        : {obj.pvt}");
            // Console.WriteLine($"prot       : {obj.prot}");
            Console.WriteLine($"pub        : {obj.pub}");
            Console.WriteLine($"inter      : {obj.inter}");
            Console.WriteLine($"protInt    : {obj.protInt}");
        }
    }
}
