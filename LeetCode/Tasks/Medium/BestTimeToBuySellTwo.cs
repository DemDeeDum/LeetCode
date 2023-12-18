namespace LeetCode.Tasks.Medium
{
    public class BestTimeToBuySellTwo
    {
        public class Solution
        {
            public int MaxProfit(int[] prices)
            {
                var tempMin = prices[0];
                var tempMax = prices[0];
                var income = 0;
                for (var j = 0; j < prices.Length; j++)
                {
                    if (tempMax > prices[j])
                    {
                        income += tempMax - tempMin;
                        tempMin = prices[j];
                        tempMax = prices[j];
                    }
                    else
                    {
                        tempMax = prices[j];
                    }
                }

                income += tempMax - tempMin;

                return income > 0 ? income : 0;
            }
        }
    }
}
