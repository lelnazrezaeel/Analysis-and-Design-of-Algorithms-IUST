using System;

namespace Q2
{
    class Program
    {
        static long Fibonachi(long n)
        {
            long[] numbers = new long[n + 2];
            numbers[0] = 0;
            numbers[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                numbers[i] = Mod(numbers[i - 1] + numbers[i - 2]);
            }
            return numbers[n];
        }
        static long Mod(long n)
        {
            const long m = 1000000007;
            return (n % m + m) % m;
        }
        static void Main(string[] args)
        {
            long n;
            n = int.Parse(Console.ReadLine());
            long fibonachi = Fibonachi(n);
            Console.WriteLine(fibonachi);
        }
    }
}
