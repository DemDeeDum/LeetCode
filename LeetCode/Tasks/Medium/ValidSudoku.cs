namespace LeetCode.Tasks.Medium
{
    internal class ValidSudoku
    {
        public class Solution
        {
            private int[][] _squrareIndex = new int[][]
            {
                new int[] { 0, 0, 0, 1, 1, 1, 2, 2, 2 },
                new int[] { 0, 0, 0, 1, 1, 1, 2, 2, 2 },
                new int[] { 0, 0, 0, 1, 1, 1, 2, 2, 2 },
                new int[] { 3, 3, 3, 4, 4, 4, 5, 5, 5 },
                new int[] { 3, 3, 3, 4, 4, 4, 5, 5, 5 },
                new int[] { 3, 3, 3, 4, 4, 4, 5, 5, 5 },
                new int[] { 6, 6, 6, 7, 7, 7, 8, 8, 8 },
                new int[] { 6, 6, 6, 7, 7, 7, 8, 8, 8 },
                new int[] { 6, 6, 6, 7, 7, 7, 8, 8, 8 },
            };

            public bool IsValidSudoku(char[][] board)
            {
                var lineIndex = 0;
                var columnIndex = 0;
                var listsForCheckLines = new List<char>[9];
                var listsForCheckColumns = new List<char>[9];
                var listsForCheckSquares = new List<char>[9];

                for (int i = 0; i < 9; i++)
                {
                    listsForCheckLines[i] = new List<char>();
                    listsForCheckColumns[i] = new List<char>();
                    listsForCheckSquares[i] = new List<char>();
                }

                while (lineIndex < 9)
                {
                    columnIndex = -1;
                    while (++columnIndex < 9)
                    {
                        if (board[lineIndex][columnIndex] == '.')
                        {
                            continue;
                        }
                        else if (listsForCheckColumns[columnIndex].Contains(board[lineIndex][columnIndex])
                            || listsForCheckLines[lineIndex].Contains(board[lineIndex][columnIndex])
                            || listsForCheckSquares[_squrareIndex[lineIndex][columnIndex]].Contains(board[lineIndex][columnIndex]))
                        {
                            return false;
                        }
                        else
                        {
                            listsForCheckColumns[columnIndex].Add(board[lineIndex][columnIndex]);
                            listsForCheckLines[lineIndex].Add(board[lineIndex][columnIndex]);
                            listsForCheckSquares[_squrareIndex[lineIndex][columnIndex]].Add(board[lineIndex][columnIndex]);
                        }
                    }

                    lineIndex++;
                }

                return true;
            }
        }
    }
}
