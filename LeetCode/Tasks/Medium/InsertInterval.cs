namespace LeetCode.Tasks.Medium
{
    internal class InsertInterval
    {
        public class Solution
        {
            public int[][] Insert(int[][] intervals, int[] newInterval)
            {
                if (intervals.Length == 0)
                {
                    return [newInterval];
                }

                var inserted = false;
                var result = new List<int[]>(intervals.Length / 2);
                for (var i = 0; i < intervals.Length; i++)
                {
                    if (!inserted && intervals[i][0] > newInterval[1])
                    {
                        inserted = true;
                        result.Add(newInterval);
                    }

                    if (intervals[i][1] >= newInterval[0] && intervals[i][0] <= newInterval[1])
                    {
                        newInterval[0] = Math.Min(intervals[i][0], newInterval[0]);
                        newInterval[1] = Math.Max(intervals[i][1], newInterval[1]);
                    }
                    else
                    {
                        result.Add(intervals[i]);
                    }
                }

                if (!inserted)
                {
                    result.Add(newInterval);
                }

                return result.ToArray();
            }
        }
    }
}
