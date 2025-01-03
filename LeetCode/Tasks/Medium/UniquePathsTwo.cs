namespace LeetCode.Tasks.Medium
{
    internal class UniquePathsTwo
    {
        public class Solution
        {
            public int UniquePathsWithObstacles(int[][] obstacleGrid)
            {
                if (obstacleGrid.Length == 0 || obstacleGrid[0].Length == 0)
                {
                    return 0;
                }

                var height = obstacleGrid.Length;
                var width = obstacleGrid[0].Length;
                var array = new int[height, width];
                var arrayOfPreviousCrosses = new int[width];
                var arrayOfLineCrosses = new int[width];
                var indexOfLineCrosses = -1;
                var indexOfPreviousLineCrosses = 0;
                for (var i = 0; i < height; i++)
                {
                    arrayOfLineCrosses[0] = -1;
                    for (var j = arrayOfPreviousCrosses[0]; j < width; j++)
                    {
                        if (obstacleGrid[i][j] == 1)
                        {
                            if (j >= arrayOfPreviousCrosses[indexOfPreviousLineCrosses] || i == 0)
                            {
                                break;
                            }

                            continue;
                        }

                        if (j > 0 && array[i, j - 1] == 0 && i > 0 && array[i - 1, j] == 0)
                        {
                            continue;
                        }

                        arrayOfLineCrosses[++indexOfLineCrosses] = j;

                        if (i == 0 || j == 0)
                        {
                            array[i, j] = 1;
                        }
                        else
                        {
                            array[i, j] = array[i - 1, j] + array[i, j - 1];
                        }
                    }

                    if (arrayOfLineCrosses[0] == -1)
                    {
                        return 0;
                    }

                    Array.Copy(arrayOfLineCrosses, arrayOfPreviousCrosses, arrayOfLineCrosses.Length);
                    indexOfPreviousLineCrosses = indexOfLineCrosses;
                    indexOfLineCrosses = -1;
                }

                return array[height - 1, width - 1];
            }
        }
    }
}
