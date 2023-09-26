using System;

namespace Q6
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            int[] cnt = new int[t];
            int n, k;
            for (int i = 0; i < t; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                n = int.Parse(inputs[0]);
                k = int.Parse(inputs[1]);
                string[] arr = Console.ReadLine().Split(' ');
                int[] numbers = new int[n];
                for (int j = 0; j < n; j++)
                    numbers[j] = int.Parse(arr[j]);
                int[] freq = new int[2 * k + 1];
                for (int j = 0; j < n / 2; j++)
                {
                    freq[numbers[j] + numbers[n - j - 1]]++;
                }

                int[] prefixSum = new int[2 * k + 1];
                prefixSum[0] = freq[0];
                for (int j = 1; j <= 2 * k; j++)
                {
                    prefixSum[j] = prefixSum[j - 1] + freq[j];
                }

                int minSwaps = int.MaxValue;
                for (int x = 2; x <= 2 * k; x++)
                {
                    int swaps = prefixSum[x - 1] - freq[x - 1] + (n / 2 - prefixSum[x]);
                    minSwaps = Math.Min(minSwaps, swaps);
                }
                cnt[i] = minSwaps;
            }
            for (int i = 0; i < t; i++)
            {
                Console.WriteLine(cnt[i]);
            }
        }
    }
}
