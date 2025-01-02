namespace LeetCode.Tasks.Medium
{
    internal class UniquePaths
    {
        public class Solution
        {
            public int UniquePaths(int m, int n)
            {
                var array = new int[m, n];
                for (var i = 0; i < m; i++)
                {
                    for (var j = 0; j < n; j++)
                    {
                        if (i == 0 || j == 0)
                        {
                            array[i, j] = 1;
                        }
                        else
                        {
                            array[i, j] = array[i - 1, j] + array[i, j - 1];
                        }
                    }
                }

                return array[m - 1, n - 1];
            }
        }
    }
}
