namespace LeetCode.Tasks.Medium
{
    internal class UniquePathsTwo
    {
        public class Solution
        {
            public int UniquePathsWithObstacles(int[][] obstacleGrid)
            {
                if (obstacleGrid.Length == 0 || obstacleGrid[0].Length == 0 || obstacleGrid[0][0] == 1)
                {
                    return 0;
                }

                var height = obstacleGrid.Length;
                var width = obstacleGrid[0].Length;
                var array = new int[height, width];
                int? indexWhenCrossedLine = null;
                var indexWhenLineBlocked = width;
                var indexWhenPreviousLineBlocked = width;
                for (var i = 0; i < height; i++)
                {
                    var crossedLine = false;
                    var j = indexWhenCrossedLine.GetValueOrDefault();
                    indexWhenCrossedLine = null;

                    for (; j < width; j++)
                    {
                        if (obstacleGrid[i][j] == 1)
                        {
                            if (height == 1)
                            {
                                return 0;
                            }

                            array[i, j] = 0;
                            indexWhenLineBlocked = Math.Min(indexWhenLineBlocked, j);

                            continue;
                        }

                        indexWhenCrossedLine = indexWhenCrossedLine.HasValue ? Math.Min(j, indexWhenCrossedLine.Value) : j;
                        if (i > 0)
                        {
                            indexWhenLineBlocked = width;
                        }

                        if (indexWhenCrossedLine >= indexWhenPreviousLineBlocked)
                        {
                            break;
                        }

                        crossedLine = true;
                        if (i == 0 || j == 0)
                        {
                            array[i, j] = 1;
                        }
                        else
                        {
                            array[i, j] = array[i - 1, j] + array[i, j - 1];
                        }
                    }

                    indexWhenPreviousLineBlocked = indexWhenLineBlocked;

                    if (!crossedLine)
                    {
                        break;
                    }
                }

                return array[height - 1, width - 1];
            }
        }
    }
}
