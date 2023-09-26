using System;

namespace Q5
{
    class Program
    {
        static void Main(string[] args)
        {
            long m = long.Parse(Console.ReadLine());
            long n = long.Parse(Console.ReadLine());
            long sum = 0;
            string[] inputs = Console.ReadLine().Split(' ');
            long[] numbers = new long[n];
            long max = -1;
            for (long i = 0; i < n; i++)
            {
                numbers[i] = long.Parse(inputs[i]);
                sum += numbers[i];
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }
            long count = 0;
            for (long i = 0; i < n; i++)
            {
                if (numbers[i] == max)
                    count += 1;
            }
            long minTime;
            if (n == 0)
                minTime = sum;
            else if (m == 0)
                minTime = 0;
            else if (m >= n - 1)
                minTime = (max - 1) * (m + 1) + count;
            else
                minTime = sum;
            Console.WriteLine(minTime);
        }
    }
}
