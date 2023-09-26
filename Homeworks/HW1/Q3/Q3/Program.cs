//Auxiliary link: https://www.geeksforgeeks.org/longest-common-subsequence-dp-4/
using System;

namespace Q3
{
    class Program
    {
        static long LCS(string[] a, string[] b)
        {
            long lenA = a.Length;
            long lenB = b.Length;
            int[,] table = new int[lenA + 1, lenB + 1];
            for (int i = 0; i < lenA + 1; i++)
            {
                for (int j = 0; j < lenB + 1; j++)
                {
                    if (i == 0 || j == 0)
                        table[i, j] = 0;
                    else if (a[i - 1] == b[j - 1])
                        table[i, j] = table[i - 1, j - 1] + 1;
                    else
                    {
                        if (table[i - 1, j] > table[i, j - 1])
                            table[i, j] = table[i - 1, j];
                        else
                            table[i, j] = table[i, j - 1];
                    }
                }
            }
            return table[lenA, lenB];
        }
        static void Main(string[] args)
        {
            string[] a = Console.ReadLine().Split(' ');
            string[] b = Console.ReadLine().Split(' ');
            Console.WriteLine(LCS(a, b));
        }
    }
}
