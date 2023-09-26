using System;

namespace Q4
{
    class Program
    {
        static void Main(string[] args)
        {
            int d = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string[] inputs = Console.ReadLine().Split(' ');
            int[] stops = new int[n + 1];
            for (int i = 0; i < n; i++)
                stops[i] = int.Parse(inputs[i]);
            stops[n] = d;
            int l = 0;
            int cnt = 0;
            for (int i = 0; i < n + 1; i++)
            {
                if (l + m < stops[i])
                {
                    l = stops[i - 1];
                    cnt += 1;
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (stops[i + 1] - stops[i] > m)
                {
                    cnt = -1;
                    break;
                }
            }
            Console.WriteLine(cnt);
        }
    }
}
