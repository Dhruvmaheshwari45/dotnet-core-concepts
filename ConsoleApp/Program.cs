// See https://aka.ms/new-console-template for more information
using System;

namespace Day1 
{
    class Program
    {
        static int AddFun(int x, int y){
            Console.WriteLine("x={0} y={1}", x, y);
            Console.WriteLine($"x={x} y={y}");

            return x + y;
        }
        // static void Main(string[] args)
        // {
        //     //Console.WriteLine("Hello, World!");
        //     Console.Write("Enter 1st number: ");
        //     int num1 = int.Parse(Console.ReadLine());

        //     Console.Write("Enter 2nd number: ");
        //     int num2 = int.Parse(Console.ReadLine());

        //     int result = AddFun(num1, num2);
        //     Console.WriteLine("Result: {0}", result);

        //     String results = String.Format("Result: {0}", result);
        //     Console.WriteLine(results);

        // }
        
        static void OutSample(out int a, out int b){
            a = 10;
            b = 20;
        }

        // static void Main(string[] args){
        //     int x, y;
        //     OutSample(out x, out y);
        //     Console.WriteLine($"Value of x: {x}, Value of y: {y}");
        // }

        static void RefSample(ref int value){
            value *= 2;
        }

        // static void Main(string[] args){
        //     int num = 5;
        //     RefSample(ref num);
        //     Console.WriteLine($"Modified value: {num}");
        // }

        static void InSample(in int value){
            // value++; // This will result in a compile-time error since 'value' is read-only
            Console.WriteLine($"Value received: {value}");
        }

        // static void Main(string[] args){
        //     int number = 10;
        //     InSample(number);
        //     Console.WriteLine($"Original value: {number}");
        // }

        static int Hcf(int a, int b){
            while(a != b){
                if( a > b){
                    a = a-b;
                }
                if(b > a){
                    b = b-a;
                }
            }
            return a;
        }

        static void Main(string[] args){
            Console.Write("Enter 1st number: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter 2nd number: ");
            int b = int.Parse(Console.ReadLine());

            int result = Hcf(a, b);
            Console.WriteLine($"Answer: {result}");
        }
    }

}