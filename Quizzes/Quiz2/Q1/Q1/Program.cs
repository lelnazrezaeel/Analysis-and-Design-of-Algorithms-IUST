using System;

namespace Q2
{
    class Program
    {
        static string ReverseString(string x, int lenX)
        {
            char[] rev = new char[lenX];
            int k = 0;
            for (int i = lenX - 1; i >= 0; i--)
            {
                rev[k] = x[i];
                k += 1;
            }
            string reverse = new string(rev);
            return reverse;
        }
        static bool Check(string str1, string str2, int lenStr1, int lenStr2)
        {
            int i = 0, j = 0;
            while (i < lenStr1 && j < lenStr2)
            {
                if (str1[i] == str2[j])
                    j += 1;
                i += 1;
            }
            if (j == lenStr2)
                return true;
            else
                return false;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool[] results = new bool[n];
            for (int k = 0; k < n; k++)
            {
                string str1 = Console.ReadLine();
                string str2 = Console.ReadLine();
                int lenStr1 = str1.Length;
                int lenStr2 = str2.Length;
                string str3 = ReverseString(str2, str2.Length);
                int lenStr3 = str3.Length;
                if (Check(str1, str2, lenStr1, lenStr2))
                    results[k] = true;
                else if (Check(str1, str3, lenStr1, lenStr3))
                    results[k] = true;
                else
                    results[k] = false;
            }
            foreach (bool result in results)
            {
                if (result)
                    Console.WriteLine("YES");
                else
                    Console.WriteLine("NO");
            }
        }
    }
}