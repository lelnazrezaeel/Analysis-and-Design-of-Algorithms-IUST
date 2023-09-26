using System;
using System.Collections.Generic;

namespace Q4
{
    class Program
    {
        static long LCIS(int[] a, int n)
        {
            SortedSet<int> sortedA = new SortedSet<int>();
            for (int i = 0; i < n; i++)
            {
                sortedA.Add(a[i]);
            }
            List<int> b = new List<int>();
            foreach (int element in sortedA)
            {
                b.Add(element);
            }
            int lenB = b.Count;
            int[,] table = new int[n + 1, lenB + 1];
            for (int i = 0; i < n + 1; i++)
            {
                for (int j = 0; j < lenB + 1; j++)
                {
                    table[i, j] = -1;
                }
            }
            for (int i = 0; i < n + 1; i++)
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
            return table[n, lenB];
        }
        static void Main(string[] args)
        {
            int n;
            n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            string[] input = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
                numbers[i] = int.Parse(input[i]);
            Console.WriteLine(LCIS(numbers, n));
        }
    }
}
