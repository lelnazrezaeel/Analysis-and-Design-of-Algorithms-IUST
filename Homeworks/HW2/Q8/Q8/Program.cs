using System;

namespace Q8
{
    class Program
    {
        static long FindIndex(long[] table, long number, long index)
        {
            long k = 0;
            while (index - k > 1)
            {
                long m = (index + k) / 2;
                if (table[m] < number)
                    k = m;
                else
                    index = m;
            }
            return index;
        }
        static long LIS(long[] numbers, long n)
        {
            long cnt = 1;
            long[] dp = new long[n];
            dp[1] = numbers[0];
            for (long i = 0; i < n; i++)
            {
                long index = FindIndex(dp, numbers[i], cnt + 1);
                dp[index] = numbers[i];
                if (index > cnt)
                    cnt = index;
            }
            return cnt;
        }
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            string[] inputs = Console.ReadLine().Split(' ');
            long[] numbers = new long[n];
            for (long i = 0; i < n; i++)
                numbers[i] = long.Parse(inputs[i]);
            Console.WriteLine(LIS(numbers, n));
        }
    }
}