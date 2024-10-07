using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PlaindromicProg
{
    public static class Palindromic
    {
        public static bool IsPalindromic(this string str)
        {
            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            string revStr = new string(chars);
            return str == revStr;
        }
        public static void Walk(int[] arr, Action<int> action)
        {
            foreach (var item in arr)
            {
                action(item);
            }
        }
    }
}
