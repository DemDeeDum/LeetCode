namespace LeetCode.Tasks.OutOfLeetCode
{
    internal class MazeProblem
    {
        /// <summary>
        /// We should reach bottom right, we are on top left
        /// We can go right or down
        /// How many ways to reach bottom right
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public long WaysToGoToRightBotton(int height, int width)
        {
            var array = new long[height, width];
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        array[i,j] = 1;
                    }
                    else
                    {
                        array[i, j] = array[i, j - 1] + array[i - 1, j];
                    }
                }
            }

            return array[height - 1, width - 1];
        }
    }
}
