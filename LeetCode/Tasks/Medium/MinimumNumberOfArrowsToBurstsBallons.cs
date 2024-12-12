namespace LeetCode.Tasks.Medium
{
    internal class MinimumNumberOfArrowsToBurstsBallons
    {
        public class Solution
        {
            public int FindMinArrowShots(int[][] points)
            {
                var numberOfArrows = 0;
                var intervals = points.OrderBy(x => x[0]).ToList();
                var min = intervals[0][0];
                var max = intervals[0][1];
                for (var i = 1; i < intervals.Count; i++)
                {
                    if (intervals[i][0] <= max)
                    {
                        min = Math.Max(intervals[i][0], min);
                        max = Math.Min(intervals[i][1], max);
                    }
                    else
                    {
                        min = intervals[i][0];
                        max = intervals[i][1];
                        numberOfArrows++;
                    }
                }

                return ++numberOfArrows;
            }
        }
    }
}
