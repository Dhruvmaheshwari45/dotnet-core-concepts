using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallBackLib1;

namespace ConsoleProj
{
    internal class CVendor1Main
    {
        static void fun1(int par1, int par2)
        {
            Console.WriteLine("Hi From Client1 p1 : {0} , p2 : {1}", par1, par2);
        }
        static int fun2(int par1, int par2)
        {
            Console.WriteLine("Hi From Client2 p1 : {0} , p2 : {1}", par1, par2);
            return par1 + par2;
        }
        static bool fun3(int par1)
        {
            Console.WriteLine("Hi From Client3 p1 : {0} , ", par1);
            return par1 <= 10;
        }
        static void Main(string[] args)
        {
            CVendor1 vendor = new CVendor1();
            FPTR fp = fun1;
            vendor.Business(fp);
            Console.WriteLine(new string('_', 50));
            FPTR1 fp1 = fun2;
            vendor.BusinessNew(fp1);
            Console.WriteLine(new string('_', 50));
            FPTR2 fp2 = fun3;
            vendor.BusinessProcess(fp2);
            Console.WriteLine(new string('_', 50));
        }
    }
}
