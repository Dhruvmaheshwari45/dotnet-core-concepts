using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDay1
{
    class Program1
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[3, 3];
            for(int i=0; i<arr.GetLength(0); i++)
            {
                for(int j=0; j<arr.GetLength(1); j++)
                {
                    //Console.Write($"{arr[i][j],-10}");
                    Console.Write($"{arr[i, j],-10}");
                }
                Console.WriteLine();
            }

        }
    }
}
