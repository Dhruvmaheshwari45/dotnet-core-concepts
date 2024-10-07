// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System.Data;

namespace Day1
{
    class Program
    {
        static int AddFun(int a, int b)
        {
            Console.WriteLine($"first value: {a} and second value: {b}");
            return a + b;
        }
        static int HCF(int a, int b)
        {
            while(a != b)
            {
                if(a > b)
                {
                    a = a - b;
                }
                if(b  > a)
                {
                    b = b - a;
                }
            }
            return a;
        }

        //factorial of a number
        static int factorialOfNumber(int num)
        {
            if(num==0 || num == 1)
            {
                return 1;
            }
            int fact = 1;
            for(int i=2; i<=num; i++)
            {
                fact = fact * i;
            }
            return fact;
        }

        static bool isFactorian(int num)
        {
            int originalNum = num;
            int sum = 0;
            while(num > 0)
            {
                int digit = num % 10;
                sum = sum + factorialOfNumber(num);
                num = num / 10;
            }
            return sum == originalNum;
        }

        //Magic square -> JackHill Problem
        static void GenerateMagicSquare(int M)
        {
            // Create a 2D array to hold the magic square
            int[,] magicSquare = new int[M, M];

            // Start position (middle of the first row)
            int row = 0;
            int col = M / 2;

            // Fill the magic square
            for (int num = 1; num <= M * M; num++)
            {
                // Place the number at the current position
                magicSquare[row, col] = num;

                // Calculate the next position
                int nextRow = (row - 1 + M) % M;  // Move to the previous row
                int nextCol = (col + 1) % M;      // Move to the next column

                // If the calculated position is already filled, move down instead
                if (magicSquare[nextRow, nextCol] != 0)
                {
                    nextRow = (row + 1) % M;  // Move down
                    nextCol = col;            // Stay in the same column
                }
                // Update row and column for the next placement
                row = nextRow;
                col = nextCol;
            }

            // Display the magic square
            Console.WriteLine("Magic Square of order " + M + ":");
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.Write(magicSquare[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello world 2");
            //Console.Write("Fisrt value: ");
            //int num1 = int.Parse(Console.ReadLine());

            //Console.Write("Second value: ");
            //int num2 = int.Parse(Console.ReadLine());

            //int result = AddFun(num1, num2);

            //int resultForHCF = HCF(num1, num2);

            //Console.WriteLine($"Result is: {result}");
            //Console.WriteLine($"Result for HCF is: {resultForHCF}");

            //Console.Write("Enter the number: ");
            //int num = int.Parse(Console.ReadLine());

            //bool result = isFactorian(num);
            //if (result)
            //{
            //    Console.WriteLine($"{num} is a factorian number");
            //}
            //else
            //{
            //    Console.WriteLine($"{num} is a not factorian number");
            //}

            Console.Write("Enter the order of the magic square (odd number): ");
            int M = int.Parse(Console.ReadLine());

            if (M % 2 == 0)
            {
                Console.WriteLine("The order must be an odd number!");
            }
            else
            {
                GenerateMagicSquare(M);
            }
        }
    }
}
