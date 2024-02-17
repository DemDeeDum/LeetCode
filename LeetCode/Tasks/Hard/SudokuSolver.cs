namespace LeetCode.Tasks.Hard
{
    internal class SudokuSolver
    {
        public class Solution
        {
            private List<char> chars = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            private int[][] squareScheme = new int[][]
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

            private (int i, int j)[][] coordinates = new (int i, int j)[][]
            {
                new (int i, int j)[] { (0, 0), (0,1), (0,2), (1,0), (1, 1), (1, 2), (2 , 0), (2, 1), (2, 2) },
                new (int i, int j)[] { (1, 3), (1,4), (1,5), (2,3), (2, 4), (2, 5), (0 , 3), (0, 4), (0, 5) },
                new (int i, int j)[] { (0, 6), (0,7), (0,8), (1,6), (1, 7), (1, 8), (2 , 6), (2, 7), (2, 8) },
                new (int i, int j)[] { (3, 0), (3,1), (3,2), (4,0), (4, 1), (4, 2), (5 , 0), (5, 1), (5, 2) },
                new (int i, int j)[] { (3, 3), (3,4), (3,5), (4,3), (4, 4), (4, 5), (5 , 3), (5, 4), (5, 5) },
                new (int i, int j)[] { (3, 6), (3,7), (3, 8), (4,6), (4, 7), (4, 8), (5 , 6), (5, 7), (5, 8) },
                new (int i, int j)[] { (6, 0), (6,1), (6,2), (7,0), (7, 1), (7, 2), (8 , 0), (8, 1), (8, 2) },
                new (int i, int j)[] { (6, 3), (6,4), (6,5), (7,3), (7, 4), (7, 5), (8 , 3), (8, 4), (8, 5) },
                new (int i, int j)[] { (6, 6), (6,7), (6,8), (7,6), (7, 7), (7, 8), (8 , 6), (8, 7), (8, 8) },
            };

            public void SolveSudoku(char[][] board)
            {
                for (var i = 0; i < board.Length; i++)
                {
                    for (var j = 0; j < board[i].Length; j++)
                    {
                        if (board[i][j] == '.')
                        {
                            board[i][j] = GetPosition(board, i, j, new char[] { });
                        }
                    }
                }
            }

            private char GetPosition(char[][] board, int i, int j, char[] skip)
            {
                var possibleCharsByLines = chars.Except(board[i]).Intersect(chars.Except(board.Select(x => x[j])));
                var square = squareScheme[i][j];
                var coordinatesOptions = coordinates[square].Where(x => !(x.i == i && x.j == j));
                var possibleBySquare = new List<char>();
                for (var k = 0; k < coordinatesOptions.Count(); k++)
                {
                    var element = coordinatesOptions.ElementAt(k);
                    if (board[element.i][element.j] == '.')
                    {
                        possibleBySquare.Add(board[element.i][element.j]);
                    }
                }

                possibleBySquare = chars.Except(possibleBySquare).ToList();

                var possibleSolution = possibleBySquare.Intersect(possibleCharsByLines).FirstOrDefault();
                if (possibleSolution != default)
                {
                    return possibleSolution;
                }
                else
                {
                    return GetPosition()
                }
            }
        }
    }
}
