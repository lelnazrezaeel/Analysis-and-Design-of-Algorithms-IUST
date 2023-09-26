using System;

namespace Q7
{
    class Program
    {
        static long LCS(string[] a, string[] b, string[] c, int lenA, int lenB, int lenC)
        {
            int[, ,] table = new int[lenA + 1, lenB + 1, lenC + 1];
            for (int i = 0; i < lenA + 1; i++)
            {
                for (int j = 0; j < lenB + 1; j++)
                {
                    for (int k = 0; k < lenC + 1; k++)
                    {
                        if (i == 0 || j == 0 || k == 0)
                            table[i, j, k] = 0;
                        else if (a[i - 1] == b[j - 1] && b[j - 1] == c[k - 1])
                            table[i, j, k] = table[i - 1, j - 1, k - 1] + 1;
                        else
                        {
                            table[i, j, k] = Math.Max(table[i - 1, j, k], Math.Max(table[i, j - 1, k], table[i, j, k - 1]));
                        }
                    }
                }
            }
            return table[lenA, lenB, lenC];
        }
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int lenA = int.Parse(inputs[0]);
            int lenB = int.Parse(inputs[1]);
            int lenC = int.Parse(inputs[2]);
            string[] a = Console.ReadLine().Split(' ');
            string[] b = Console.ReadLine().Split(' ');
            string[] c = Console.ReadLine().Split(' ');
            Console.WriteLine(LCS(a, b, c, lenA, lenB, lenC));
        }
    }
}
