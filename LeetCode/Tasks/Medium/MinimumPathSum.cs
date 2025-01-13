namespace LeetCode.Tasks.Medium
{
    internal class MinimumPathSum
    {
        public class Solution
        {
            public int MinPathSum(int[][] grid)
            {
                var memo = new int[grid.Length, grid[0].Length];

                for (var i = 0; i < grid.Length; i++)
                {
                    for (var j = 0; j < grid[0].Length; j++)
                    {
                        var value = grid[i][j];
                        var jZero = j == 0;
                        var iZero = i == 0;
                        if (iZero && jZero)
                        {
                        }
                        else if (!jZero && !iZero)
                        {
                            value += Math.Min(memo[i - 1, j], memo[i, j - 1]);
                        }
                        else if (jZero)
                        {
                            value += memo[i - 1, j];
                        }
                        else if (iZero)
                        {
                            value += memo[i, j - 1];
                        }

                        memo[i, j] = value;
                    }
                }

                return memo[grid.Length - 1, grid[0].Length - 1];
            }
        }
    }
}
