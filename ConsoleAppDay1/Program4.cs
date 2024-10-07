using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDay1
{
    abstract class CArray
    {
        int[] arr = { 10, 40, 30, 50, 20, 60, 90, 70, 100, 80 };
        private void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
        protected abstract bool Condition(int x, int y);

        public void Sort()
        {
            int n = arr.Length;
            bool swapped;
            for(int i=0; i<n - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (Condition(arr[j], arr[j + 1]))
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                        swapped = true;
                    }
                }
                if (!swapped)
                    break;
            }
        }
        public void Show()
        {
            foreach (int i in arr)
            {
                Console.Write("{0,-10}", i);
            }
            Console.WriteLine();
        }
    }
    class CArrAsc : CArray
    {
        protected override bool Condition(int x, int y)
        {
            return x > y;
        }
    }

    class CArrDesc : CArray
    {
        protected override bool Condition(int x, int y)
        {
            return x < y;
        }
    }
    class Program4
    {
        static void Main(string[] args)
        {
            CArrAsc cArrayAsc = new CArrAsc();
            cArrayAsc.Show();

            CArrDesc cArrDesc = new CArrDesc();
            cArrDesc.Show();

            Console.WriteLine(new string('*', 100));
            cArrayAsc.Sort();
            cArrDesc.Sort();
            cArrayAsc.Show();
            cArrDesc.Show();
        }
    }
}
