using System;

namespace Q7
{
    class Program
    {
        static long BestPath(long n, long p, long[] path1, long[] path2)
        {
            long[] score1 = new long[n];
            long[] score2 = new long[n];
            score1[0] = path1[0];
            score2[0] = path2[0];
            for (long i = 1; i < n; i++)
            {
                if (score1[i - 1] > score2[i - 1] - p)
                    score1[i] = score1[i - 1] + path1[i];
                else
                    score1[i] = score2[i - 1] + path1[i] - p;
                if (score2[i - 1] > score1[i - 1] - p)
                    score2[i] = score2[i - 1] + path2[i];
                else
                    score2[i] = score1[i - 1] + path2[i] - p;
            }
            if (score1[n - 1] > score2[n - 1])
                return score1[n - 1];
            else
                return score2[n - 1];
        }
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            string[] arr1 = Console.ReadLine().Split(' ');
            string[] arr2 = Console.ReadLine().Split(' ');
            long n = long.Parse(input[0]);
            long p = long.Parse(input[1]);
            long[] path1 = new long[n];
            long[] path2 = new long[n];
            for (long i = 0; i < n; i++)
            {
                path1[i] = long.Parse(arr1[i]);
                path2[i] = long.Parse(arr2[i]);
            }
            Console.WriteLine(BestPath(n, p, path1, path2));
        }
    }
}
