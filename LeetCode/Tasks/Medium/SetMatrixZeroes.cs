namespace LeetCode.Tasks.Medium
{
    internal class SetMatrixZeroes
    {
        public class Solution
        {
            public void SetZeroes(int[][] matrix)
            {
                var columnToZero = new List<int>();
                var lineToZero = new List<int>();

                for (int i = 0; i < matrix.Length; i++)
                {
                    for (var j = 0; j < matrix[i].Length; j++)
                    {
                        if (matrix[i][j] == 0)
                        {
                            if (!columnToZero.Contains(j))
                            {
                                columnToZero.Add(j);
                            }
                            if (!lineToZero.Contains(i))
                            {
                                lineToZero.Add(i);
                            }
                        }
                    }
                }

                foreach (var j in columnToZero)
                {
                    for (var i = 0; i < matrix.Length; i++)
                    {
                        matrix[i][j] = 0;
                    }
                }

                foreach (var i in lineToZero)
                {
                    for (var j = 0; j < matrix[i].Length; j++)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
        }
    }
}
