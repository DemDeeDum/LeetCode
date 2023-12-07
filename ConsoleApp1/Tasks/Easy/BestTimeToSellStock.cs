namespace LeetCode.Tasks.Easy
{
    internal class BestTimeToSellStock
    {
        public class Solution
        {
            public int MaxProfit(int[] prices)
            {
                var tempDifference = 0;
                var tempMin = prices[0];
                var tempMax = prices[0];
                var difference = 0;
                for (var j = 0; j < prices.Length; j++)
                {
                    if (prices[j] < tempMin)
                    {
                        tempDifference = tempMax - tempMin;
                        if (tempDifference > difference)
                        {
                            difference = tempDifference;
                        }

                        tempMax = prices[j];
                        tempMin = prices[j];
                    }

                    if (tempMax < prices[j])
                    {
                        tempMax = prices[j];
                    }
                }

                tempDifference = tempMax - tempMin;
                if (tempDifference > difference)
                {
                    difference = tempDifference;
                }

                return difference > 0 ? difference : 0;
            }
        }
    }
}
