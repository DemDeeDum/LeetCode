namespace LeetCode.Tasks.Medium
{
    internal class MergeIntervals
    {
        public class Solution
        {
            public int[][] Merge(int[][] intervals)
            {
                var mergedIntervals = new LinkedList<int[]>();

                foreach (var interval in intervals)
                {
                    var newInterval = new int[2] { interval[0], interval[1] };
                    var node = mergedIntervals.First;
                    while (node != null)
                    {
                        var current = node;
                        node = node.Next;
                        if (current.Value[0] <= newInterval[1] && current.Value[1] >= newInterval[0])
                        {
                            newInterval[1] = Math.Max(newInterval[1], current.Value[1]);
                            newInterval[0] = Math.Min(newInterval[0], current.Value[0]);

                            mergedIntervals.Remove(current);
                        }
                    }

                    mergedIntervals.AddFirst(newInterval);
                }

                return mergedIntervals.ToArray();
            }
        }
    }
}
