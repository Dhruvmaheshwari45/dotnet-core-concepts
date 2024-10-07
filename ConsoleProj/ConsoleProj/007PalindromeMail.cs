using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PlaindromicProg;

namespace ConsoleProj
{
    public class PalindromeMain
    {
        static void Main1(string[] args)
        {
            string str = "naman";
            if (str.IsPalindromic())
            {
                Console.WriteLine("Palindrome");
            }
            else
            {
                Console.WriteLine("Not Palindrome");
            }
            Console.WriteLine(new string('_', 50));
        }
        static void MyDisplay(int val)
        {
            Console.Write("{0, -5}", val);
        }
        static void Main2(string[] args)
        {
            int[] arr = { 10, 20, 30, 40, 50, 60, 70, 80 };
            Array.ForEach(arr, MyDisplay);
        }

        static void Main3(string[] args)
        {
            int x = 100;
            int y = 200;
            int[] arr = { 10, 20, 30, 40, 50, 60, 70, 80 };

            Action<int> action = delegate (int a) { Console.WriteLine("Anonymous : {0,-5} x:{1} y:{2}", a, x, y); };
            Array.ForEach(arr, action);
        }
        static void Main(string[] args)
        {
            int x = 100;
            int y = 200;
            int[] arr = { 10, 20, 30, 40, 50, 60, 70 };
            //Anonymous Function (closure)
            Action<int> act = (int a) => { Console.WriteLine("Lambda : {0,-5} x:{1} y:{2}", a, x, y); };
            //CVendor3.Walk(arr,act);
            Array.ForEach(arr, act);
        }
    }
}
