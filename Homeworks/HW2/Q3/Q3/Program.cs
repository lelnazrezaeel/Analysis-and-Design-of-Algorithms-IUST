using System;

namespace Q3
{
    class Program
    {
        static void MinimumCost(ulong n, ulong m, ulong[] arr)
        {
            ulong[,] dp = new ulong[m + 1, n + 1];
            for (ulong i = 0; i <= m; i++)
                for (ulong j = 0; j <= n; j++)
                    dp[i, j] = 10000000000;
            dp[0, 0] = 0;
            //dp[0, n] = ulong.MaxValue;
            for (ulong i = 0; i <= m; i++)
            {
                for (ulong j = 1; j <= n; j++)
                {
                    for (ulong k = 1; k <= Math.Sqrt(i); k++)
                    {
                        dp[i, j] = Math.Min(dp[i, j], dp[i - (ulong)(Math.Pow(k, 2)), j - 1] + (ulong)Math.Pow(arr[j - 1] - k, 2));
                    }
                }
            }
            /* for (ulong i = 0; i <= m; i++)
             {
                 for (ulong j = 0; j <= n; j++)
                 {
                     Console.Write(dp[i, j] + " ");
                 }
                 Console.WriteLine();
             }*/
            if (dp[m, n] == 10000000000)
                Console.WriteLine("-1");
            else
                Console.WriteLine(dp[m, n]);
        }
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            ulong n = ulong.Parse(inputs[0]);
            ulong m = ulong.Parse(inputs[1]);
            ulong[] arr = new ulong[n];
            for (ulong i = 0; i < n; i++)
                arr[i] = ulong.Parse(Console.ReadLine());
            MinimumCost(n, m, arr);
        }
    }
}
