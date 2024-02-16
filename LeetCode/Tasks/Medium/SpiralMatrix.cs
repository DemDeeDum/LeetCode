namespace LeetCode.Tasks.Medium
{
    internal class SpiralMatrix
    {
        public class Solution
        {
            public IList<int> SpiralOrder(int[][] matrix)
            {
                var lineLength = matrix[0].Length;
                var list = new List<int>(matrix.Length * lineLength);
                var verticalOffset = 0;
                var horizontalOffset = 0;

                while (verticalOffset * 2 < matrix.Length && horizontalOffset * 2 < lineLength)
                {
                    list.AddRange(TakeRight(horizontalOffset, verticalOffset, matrix));
                    list.AddRange(TakeBottom(horizontalOffset, verticalOffset, matrix));
                    list.AddRange(TakeLeft(horizontalOffset, verticalOffset, matrix));
                    list.AddRange(TakeTop(horizontalOffset, verticalOffset, matrix));

                    verticalOffset++;
                    horizontalOffset++;
                }

                return list;
            }

            private IEnumerable<int> TakeRight(int horizontalOffset, int verticalOffset, int[][] matrix)
            {
                return matrix[verticalOffset].Skip(horizontalOffset).Take(matrix[verticalOffset].Length - horizontalOffset * 2);
            }

            private IEnumerable<int> TakeBottom(int horizontalOffset, int verticalOffset, int[][] matrix)
            {
                return matrix.Skip(verticalOffset + 1).Take(matrix.Length - verticalOffset * 2 - 1).Select(x => x[x.Length - horizontalOffset - 1]);
            }

            private IEnumerable<int> TakeLeft(int horizontalOffset, int verticalOffset, int[][] matrix)
            {
                var lineIndex = matrix.Length - verticalOffset - 1;
                if (lineIndex == verticalOffset)
                {
                    return Enumerable.Empty<int>();
                }

                return matrix[lineIndex].Reverse().Skip(horizontalOffset + 1).Take(matrix[lineIndex].Length - horizontalOffset * 2 - 1);
            }

            private IEnumerable<int> TakeTop(int horizontalOffset, int verticalOffset, int[][] matrix)
            {
                if (matrix[0].Length - horizontalOffset - 1 == horizontalOffset)
                {
                    return Enumerable.Empty<int>();
                }

                return matrix.Reverse().Skip(verticalOffset + 1).Take(matrix.Length - verticalOffset * 2 - 2).Select(x => x[horizontalOffset]);
            }
        }
    }
}
