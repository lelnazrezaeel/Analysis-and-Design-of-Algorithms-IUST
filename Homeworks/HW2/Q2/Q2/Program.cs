using System;

namespace Q1
{
    class Program
    {
        static int MinimumCoins(int[] coins, int target)
        {
            int[] dp = new int[target + 1];
            dp[0] = 0;
            for (int i = 1; i <= target; i++)
                dp[i] = target + 1;
            for (int sum = 1; sum <= target; sum++)
            {
                foreach (int coin in coins)
                {
                    if (sum - coin >= 0)
                    {
                        dp[sum] = Math.Min(dp[sum], dp[sum - coin] + 1);
                    }
                }
            }
            if (dp[target] == target + 1)
                return -1;
            return dp[target];
        }
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split();
            int n = int.Parse(inputs[0]);
            int target = int.Parse(inputs[1]);
            string[] array = Console.ReadLine().Split();
            int[] coins = new int[n];
            for (int i = 0; i < n; i++)
                coins[i] = int.Parse(array[i]);
            int min = MinimumCoins(coins, target);
            Console.WriteLine(min);
        }
    }
}
