namespace LeetCode.Tasks.Hard
{
    public class BestTimeToBuySellThree
    {
        public class Solution
        {
            public int MaxProfit(int[] prices)
            {
                var possibleIncomes = new System.Collections.Generic.SortedList<PossibleIncome>();
                for (var j = 0; j < prices.Length; j++)
                {
                    var difference = 0;
                    for (var i = j + 1; i < prices.Length; i++)
                    {
                        var potentialSum = prices[j] - prices[i];
                        if (potentialSum > 0)
                        {
                            possibleIncomes.Add(new PossibleIncome { IndexMax = i, IndexMin = j, Sum = potentialSum });
                        }
                    }
                }

                return difference > 0 ? difference : 0;
            }

            struct PossibleIncome
            {
                public decimal Sum { get; set; }

                public int IndexMin { get; set; }

                public int IndexMax { get; set; }
            }
        }
    }
}
