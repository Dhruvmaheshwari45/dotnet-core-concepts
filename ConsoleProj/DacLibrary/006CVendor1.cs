using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallBackLib1
{
    public delegate void FPTR(int x, int y);
    public delegate int FPTR1(int x, int y);
    public delegate bool FPTR2(int x);

    public class CVendor1
    {
        public void Business(FPTR fp)
        {
            Console.WriteLine("Apple Ooty");
            fp(404, 401);//callback
            Console.WriteLine("Apple Shimla");
        }
        public void BusinessNew(FPTR1 fp)
        {
            Console.WriteLine("Rahul Dravid");
            int res = fp(10, 20);//callback
            Console.WriteLine("Rajini Kanth res : {0}", res);
        }
        public void BusinessProcess(FPTR2 fp)
        {
            Console.WriteLine("Sri Devi");
            bool res = fp(10);//callback
            if (res)
                Console.WriteLine("Konda Seval Koovum Neram by Shankar Ganesh");
            else
                Console.WriteLine("Abbani Thiyani Debba by Ilayaraja");
        }
    }
}
