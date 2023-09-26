using System;

class Program
{
    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        long W = long.Parse(inputs[0]);
        long n = long.Parse(inputs[1]);
        string[] costs = Console.ReadLine().Split(' ');
        string[] weights = Console.ReadLine().Split(' ');
        long[] c = new long[n];
        long[] w = new long[n];
        double[] r = new double[n];
        double price = 0;
        long capacity = W;
        for (long i = 0; i < n; i++)
        {
            c[i] = long.Parse(costs[i]);
            w[i] = long.Parse(weights[i]);
            r[i] = (double)c[i] / w[i];
        }
        while (capacity > 0)
        {
            long idx = -1;
            double max = 0;
            for (long i = 0; i < n; i++)
            {
                if (w[i] > 0)
                {
                    if (r[i] > max)
                    {
                        idx = i;
                        max = r[i];
                    }
                }
            }
            if (idx == -1)
            {
                break;
            }
            long weight = Math.Min(w[idx], capacity);
            capacity -= weight;
            w[idx] -= weight;
            price += weight * max;
        }
        Console.WriteLine("{0:0.00}", price);
    }
}
