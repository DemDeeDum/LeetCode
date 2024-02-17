namespace LeetCode.Tasks.Medium
{
    internal class RotateImage
    {
        public class Solution
        {
            public void Rotate(int[][] matrix)
            {
                var offset = 0;

                while (offset * 2 + 1 < matrix.Length)
                {
                    var right = matrix[offset].Skip(offset).Take(matrix.Length - offset * 2 - 1).ToArray();
                    var bottom = matrix.Skip(offset).Take(matrix.Length - offset * 2 - 1).Select(x => x[x.Length - offset - 1]).ToArray();
                    var left = matrix[matrix.Length - offset - 1].Reverse().Skip(offset).Take(matrix.Length - offset * 2 - 1).ToArray();
                    var top = matrix.Reverse().Skip(offset).Take(matrix.Length - offset * 2 - 1).Select(x => x[offset]).ToArray();

                    for (int i = 0, j = offset; i < top.Length; j++, i++)
                    {
                        matrix[offset][j] = top[i];
                    }

                    var column = matrix.Length - offset - 1;
                    for (int i = 0, j = offset; i < right.Length; j++, i++)
                    {
                        matrix[j][column] = right[i];
                    }

                    var line = matrix.Length - offset - 1;
                    for (int i = 0, j = line; i < bottom.Length; j--, i++)
                    {
                        matrix[line][j] = bottom[i];
                    }

                    for (int i = 0, j = matrix.Length - offset - 1; i < left.Length; j--, i++)
                    {
                        matrix[j][offset] = left[i];
                    }

                    offset++;
                }
            }
        }
    }
}
