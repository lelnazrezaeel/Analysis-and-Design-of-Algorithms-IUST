using System;

namespace Q5
{
    class Program
    {
        static long Sum(long[] numbers, long start, long end)
        {
            long s = 0;
            for (long i = start; i < start + end + 2; i++)
                s += numbers[i];
            return s;
        }
        static long MergeSort(long[] numbers, long n)
        {
            long[, ] dp = new long[n, n];
            long t = n - 1, min,  result;
            for (long i = 0; i < n - 1; i++)
            {
                for (long j = 0; j < t; j++)
                {
                    min = 10000000000000;
                    for (long k = 0; k < i + 1; k++)
                    {
                        result = dp[j, j + k] + dp[j + k + 1, i + j + 1] + Sum(numbers, j, i);
                        if (result < min)
                            min = result;
                    }
                    dp[j, j + i + 1] = min;
                }
                t -= 1;
            }
            return dp[0, n - 1];
        }
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            long n = long.Parse(inputs[0]);
            long k = long.Parse(inputs[1]);
            long[] numbers = new long[k];
            string[] arr = Console.ReadLine().Split(' ');
            for (long i = 0; i < k; i++)
                numbers[i] = long.Parse(arr[i]);
            Console.WriteLine(MergeSort(numbers, k));
        }
    }
}