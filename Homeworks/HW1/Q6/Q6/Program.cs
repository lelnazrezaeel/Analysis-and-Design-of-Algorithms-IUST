using System;

namespace Q6
{
    class Program
    {
        static void CalculateWays(int n, int[] numbers, int s)
        {
            int[] table = new int[s + 1];
            table[0] = 1;
            for (int i = 1; i < s + 1; i++)
            {
                foreach (int num in numbers)
                {
                    if (i >= num)
                        table[i] += table[i - num];
                }
            }
                  
            if (table[s] == 0)
                Console.WriteLine("Empty");
            else
                Console.WriteLine(table[s]);
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(' ');
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
                numbers[i] = int.Parse(input[i]);
            int s = int.Parse(Console.ReadLine());
            CalculateWays(n, numbers, s);
        }
    }
}
