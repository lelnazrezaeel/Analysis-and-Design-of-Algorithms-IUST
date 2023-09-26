using System;
using System.Linq;

namespace Q3
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            long[][] p = new long[n][];
            for (long i = 0; i < n; i++)
            {
                long[] inputs = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                p[i] = inputs;
            }
            Array.Sort(p, (a, b) => a[1].CompareTo(b[1]));
            long selected = p[0][1];
            long count = 1;
            for (long i = 1; i < n; i++)
            {
                if (selected >= p[i][0] && selected <= p[i][1])
                    continue;
                selected = p[i][1];
                count += 1;
            }
            Console.WriteLine(count);
        }
    }
}
