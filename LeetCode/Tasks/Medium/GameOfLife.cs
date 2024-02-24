namespace LeetCode.Tasks.Medium
{
    internal class GameOfLife
    {
        public class Solution
        {
            public void GameOfLife(int[][] board)
            {
                var boardLength = board[0].Length;
                var bufferA = new int[boardLength];
                var bufferB = new int[boardLength];

                for (var i = 0; i < board.Length; i++)
                {
                    var even = i % 2 == 0;
                    var bufferToWriteFrom = even ? bufferB : bufferA;
                    var bufferToWriteTo = even ? bufferA : bufferB;
                    for (var j = 0; j < boardLength; j++)
                    {
                        bufferToWriteTo[j] = GetNextValue(board, i, j);
                    }

                    var lineIndex = i - 1;
                    if (lineIndex >= 0)
                    {
                        for (var j = 0; j < boardLength; j++)
                        {
                            board[lineIndex][j] = bufferToWriteFrom[j];
                        }
                    }

                    if (i == board.Length - 1)
                    {
                        for (var j = 0; j < boardLength; j++)
                        {
                            board[i][j] = bufferToWriteTo[j];
                        }
                    }
                }
            }

            private int GetNextValue(int[][] board, int i, int j)
            {
                var numberOfAlives = 0;
                var iBiggerThanZero = i > 0;
                var jBiggerThanZero = j > 0;
                var iNotLast = i < board.Length - 1;
                var jNotLast = j < board[board.Length - 1].Length - 1;

                if (iBiggerThanZero)
                {
                    numberOfAlives += jBiggerThanZero ? board[i - 1][j - 1] : 0;
                    numberOfAlives += board[i - 1][j];
                    numberOfAlives += jNotLast ? board[i - 1][j + 1] : 0;
                }

                if (iNotLast)
                {
                    numberOfAlives += jNotLast ? board[i + 1][j + 1] : 0;
                    numberOfAlives += board[i + 1][j];
                    numberOfAlives += jBiggerThanZero ? board[i + 1][j - 1] : 0;
                }

                numberOfAlives += jNotLast ? board[i][j + 1] : 0;
                numberOfAlives += jBiggerThanZero ? board[i][j - 1] : 0;

                return numberOfAlives > 3 ? 0 : numberOfAlives == 3 ? 1 : numberOfAlives == 2 ? board[i][j] : 0;
            }
        }
    }
}
