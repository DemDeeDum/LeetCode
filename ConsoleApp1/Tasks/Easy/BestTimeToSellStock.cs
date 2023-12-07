namespace LeetCode.Tasks.Easy
{
    internal class BestTimeToSellStock
    {
        public class Solution
        {
            public int MaxProfit(int[] prices)
            {
                var maxDifference = 0;
                for (var j = 0; j < prices.Length; j++)
                {
                    for (var i = prices.Length - 1; i >= j; i--)
                    {
                        var difference = prices[j] - prices[i];
                        if (difference > maxDifference)
                        {
                            maxDifference = difference;
                        }
                    }
                }

                return maxDifference;
            }
        }
    }
}
