namespace LeetCode.Tasks.Medium
{
    internal class ValidSudoku
    {
        public class Solution
        {
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
                            || GetSquareList(listsForCheckSquares, lineIndex, columnIndex).Contains(board[lineIndex][columnIndex]))
                        {
                            return false;
                        }
                        else
                        {
                            listsForCheckColumns[columnIndex].Add(board[lineIndex][columnIndex]);
                            listsForCheckLines[lineIndex].Add(board[lineIndex][columnIndex]);
                            GetSquareList(listsForCheckSquares, lineIndex, columnIndex).Add(board[lineIndex][columnIndex]);
                        }
                    }

                    lineIndex++;
                }

                return true;
            }

            private List<char> GetSquareList(List<char>[] lists, int lineIndex, int columnIndex)
            {
                var lineNumber = lineIndex < 3 ? 1 : lineIndex < 6 ? 2 : 3;
                var columnNumber = columnIndex < 3 ? 1 : columnIndex < 6 ? 2 : 3;
                var index = GetIndex(lineNumber, columnNumber);

                return lists[index];
            }

            private int GetIndex(int lineNumber, int columnNumber)
            {
                if (lineNumber == 1)
                {
                    return columnNumber == 1 ? 0 : columnNumber == 2 ? 1 : 2;
                }
                else if (lineNumber == 2)
                {
                    return columnNumber == 1 ? 3 : columnNumber == 2 ? 4 : 5;
                }
                else
                {
                    return columnNumber == 1 ? 6 : columnNumber == 2 ? 7 : 8;
                }
            }
        }
    }
}
