using System;
using System.Linq;

namespace Q8
{
    class Program
    {
        static int Min(string input)
        {
            int n = input.Length;
            int[] table = new int[n];
            for (int i = 0; i < n; i++)
                if (Char.IsUpper(input[i]))
                    table[0] += 1;
            if (table[0] == n || table[0] == 0)
                return 0;
            for (int i = 1; i < n; i++)
                if (Char.IsUpper(input[i - 1]))
                    table[i] = table[i - 1] - 1;
                else
                    table[i] = table[i - 1] + 1;
            return table.Min();
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(Min(input));
        }
    }
}
