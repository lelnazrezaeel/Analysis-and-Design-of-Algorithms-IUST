using System;

namespace Q4
{
    class Program
    {
        static long MinimumCost(int[] numbers, int n, int b)
        {
            long[,,] dp = new long[b + 1, b + 1, 2];
            for (int i = 0; i < b + 1; i++)
            {
                for (int j = 0; j < b + 1; j++)
                { 
                    if (i == 0 && j == 0)
                    {
                        dp[i, j, 0] = 0;
                        dp[i, j, 1] = 0;
                    }
                    else
                    {
                        dp[i, j, 0] = 1000000000000;
                        dp[i, j, 1] = 1000000000000;
                    }
                }
            }
            for (int i = 0; i < b + 1; i++)
            {
                for (int j = 0; j < b + 1; j++)
                {
                    if (n < i + j)
                    {
                        break;
                    }
                    if (i != 0)
                    {
                        dp[i, j, 0] = Math.Min(dp[i - 1, j, 0], dp[i - 1, j, 1] + numbers[i + j - 1]);
                    }
                    if (j != 0)
                    {
                        dp[i, j, 1] = Math.Min(dp[i, j - 1, 1], dp[i, j - 1, 0] + numbers[i + j - 1]);
                    }
                }
            }

            long max = 1000000000000;
            for (int i = 0; i < b + 1; i++)
            {
                for (int j = 0; j < b + 1; j++)
                {
                    if (i + j > n)
                    {
                        break;
                    }
                    if (i + j == n)
                    {
                        max = Math.Min(Math.Min(dp[i, j, 1], dp[i, j, 0]), max);
                    }
                }
            }
            return max;
        }
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int n = int.Parse(inputs[0]);
            int b = int.Parse(inputs[1]);
            string[] array = Console.ReadLine().Split(' ');
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
                numbers[i] = int.Parse(array[i]);
            Console.WriteLine(MinimumCost(numbers, n, b));
        }
    }
}
