namespace LeetCode.Tasks.Easy
{
    internal class FindCenterOfStarGraph
    {
        public class Solution
        {
            public int FindCenter(int[][] edges)
            {
                var first = edges[0];
                var second = edges[1];

                return first[0] == second[0] || first[0] == second[1]
                    ? first[0]
                    : first[1];
            }
        }
    }
}
