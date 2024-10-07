using System;
using DacLibraryAccessModifier;

namespace ConsoleProj
{
    class CC : CA
    {
        public void DisplayCC()
        {
            //Console.WriteLine($"pvt        : {pvt}"); // Error
            Console.WriteLine($"prot       : {prot}");
            Console.WriteLine($"pub        : {pub}");
            //Console.WriteLine($"inter      : {inter}");
            Console.WriteLine($"protInt    : {protInt}");
        }
    }
    internal class CMain1
    {
        static void Main(string[] args)
        {
            CA obj = new CA();
            // Console.WriteLine($"pvt        : {obj.pvt}");
            // Console.WriteLine($"prot       : {obj.prot}");
            Console.WriteLine($"pub        : {obj.pub}");
            // Console.WriteLine($"inter      : {obj.inter}");
            // Console.WriteLine($"protInt    : {obj.protInt}");

        }
    }
}
