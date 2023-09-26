using System;

namespace Q2_1
{
    class Program
    {
        static int Grater(int a, int b)
        {
            if (a > b)
                return a;
            else
                return b;
        }
        static int Smaller(int a, int b)
        {
            if (a < b)
                return a;
            else
                return b;
        }
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            int k = int.Parse(input[1]);
            int[,] dp = new int[k + 1, n + 1];
            for (int i = 1; i <= n; i++)
                dp[1, i] = i;
            for (int i = 2; i <= k; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    dp[i, j] = int.MaxValue;
                    int a = 1;
                    int b = j;
                    while (a <= b)
                    {
                        int m = (a + b) / 2;
                        int brk = dp[i - 1, m - 1];
                        int nrk = dp[i, j - m];
                        dp[i, j] = Smaller(dp[i, j], Grater(brk, nrk) + 1);
                        if (brk < nrk)
                        {
                            a = m + 1;
                        }
                        else
                        {
                            b = m - 1;
                        }
                    }
                }
            }
            Console.WriteLine(dp[k, n]);
        }
    }
}