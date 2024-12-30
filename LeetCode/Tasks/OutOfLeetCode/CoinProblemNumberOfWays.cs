namespace LeetCode.Tasks.OutOfLeetCode
{
    internal class CoinProblemNumberOfWays
    {
        public int NumberOfWaysToReachTheSum(int[] coins, int sum) // bottom up
        {
            var memo = new int[sum + 1];
            memo[0] = 1;

            foreach (var i in Enumerable.Range(1, sum))
            {
                memo[i] = 0;

                for (var cIndex = 0; cIndex < coins.Length; cIndex++)
                {
                    var subProblem = i - coins[cIndex];
                    if (subProblem < 0)
                    {
                        continue;
                    }

                    memo[i] += memo[subProblem];
                }
            }

            return memo[sum];
        }
        
        private int DP(int[] coins, int sum, int?[] memo) // recursion
        {
            if (memo[sum].HasValue)
            {
                return memo[sum]!.Value;
            }

            var result = 0;
            for (var i = 0; i < coins.Length; i++)
            {
                var subSum = sum - coins[i];
                if (subSum == 0)
                {
                    result++;
                }
                else if (subSum > 0)
                {
                    result += DP(coins, subSum, memo);
                }
            }

            memo[sum] = result;

            return result;
        }
    }
}
