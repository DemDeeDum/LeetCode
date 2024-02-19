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

            private Dictionary<int, IList<DataItem>> coordinatesToSolvePerSquare = new Dictionary<int, IList<DataItem>>();
            private Dictionary<int, IList<DataItem>> coordinatesToSolvePerLine = new Dictionary<int, IList<DataItem>>();
            private Dictionary<int, IList<DataItem>> coordinatesToSolvePerColumn = new Dictionary<int, IList<DataItem>>();
            private Dictionary<string, IList<char>> cache = new Dictionary<string, IList<char>>();

            public void SolveSudoku(char[][] board)
            {
                for (var i = 0; i < coordinates.Length; i++)
                {
                    coordinatesToSolvePerSquare.Add(i, new List<DataItem>());
                    for (var j = 0; j < coordinates[i].Length; j++)
                    {
                        var current = coordinates[i][j];
                        if (board[current.i][current.j] == '.')
                        {
                            var dataItem = new DataItem(current.i, current.j, i);
                            coordinatesToSolvePerSquare[i].Add(dataItem);

                            if (coordinatesToSolvePerLine.ContainsKey(current.i))
                            {
                                coordinatesToSolvePerLine[current.i].Add(dataItem);
                            }
                            else
                            {
                                coordinatesToSolvePerLine.Add(current.i, new List<DataItem> { dataItem });
                            }

                            if (coordinatesToSolvePerColumn.ContainsKey(current.j))
                            {
                                coordinatesToSolvePerColumn[current.j].Add(dataItem);
                            }
                            else
                            {
                                coordinatesToSolvePerColumn.Add(current.j, new List<DataItem> { dataItem });
                            }
                        }
                    }

                    SetUpValues(board, coordinatesToSolvePerSquare[i]);
                }

                while (coordinatesToSolvePerSquare.Any())
                {
                    foreach (var squareWithCoordinates in coordinatesToSolvePerSquare)
                    {
                        SetUpValues(board, squareWithCoordinates.Value);
                    }

                    foreach (var lineWithCoordinates in coordinatesToSolvePerLine)
                    {
                        SetUpValues(board, lineWithCoordinates.Value);
                    }

                    foreach (var columnWithCoordinates in coordinatesToSolvePerColumn)
                    {
                        SetUpValues(board, columnWithCoordinates.Value);
                    }
                }
            }

            private void SetUpValues(char[][] board, IList<DataItem> coordinatesToSolve)
            {
                foreach (var item in coordinatesToSolve)
                {
                    FindPositions(board, item.I, item.J);
                }

                var values = coordinatesToSolve.Select(x => (Coordinates: x, Values: cache[GetKey(x.I, x.J)]));
                for (int i = 0; i < values.Count(); i++)
                {
                    var element = values.ElementAt(i);
                    var otherValues = values.Where(x => element.Coordinates != x.Coordinates);
                    var uniqueValues = element.Values.Where(x => otherValues.All(y => !y.Values.Contains(x)));
                    var uniqueValue = uniqueValues.Count() == 1 ? uniqueValues.First() : default;

                    if (uniqueValue != default)
                    {
                        board[element.Coordinates.I][element.Coordinates.J] = uniqueValue;

                        coordinatesToSolvePerSquare[element.Coordinates.SquareIndex].Remove(element.Coordinates);
                        coordinatesToSolvePerLine[element.Coordinates.I].Remove(element.Coordinates);
                        coordinatesToSolvePerColumn[element.Coordinates.J].Remove(element.Coordinates);
                        if (!coordinatesToSolvePerSquare[element.Coordinates.SquareIndex].Any())
                        {
                            coordinatesToSolvePerSquare.Remove(element.Coordinates.SquareIndex);
                        }

                        if (!coordinatesToSolvePerLine[element.Coordinates.I].Any())
                        {
                            coordinatesToSolvePerLine.Remove(element.Coordinates.I);
                        }

                        if (!coordinatesToSolvePerColumn[element.Coordinates.J].Any())
                        {
                            coordinatesToSolvePerColumn.Remove(element.Coordinates.J);
                        }

                        cache[GetKey(element.Coordinates.I, element.Coordinates.J)] = element.Values;

                        values = otherValues;
                    }

                    foreach (var item in values)
                    {
                        FindPositions(board, item.Coordinates.I, item.Coordinates.J);
                    }
                }
            }

            private void FindPositions(char[][] board, int i, int j)
            {
                var possibleByLine = chars.Except(board[i]);
                var possibleByColumn = chars.Except(board.Select(x => x[j]));
                var possibleBySquare = chars.Except(coordinates[squareScheme[i][j]]
                    .Where(x => !(x.i == i && x.j == j) && board[x.i][x.j] != '.')
                    .Select(x => board[x.i][x.j]));

                cache[GetKey(i, j)] = possibleBySquare.Intersect(possibleByColumn).Intersect(possibleByLine).ToList();
            }

            private string GetKey(int i, int j) => $"{i}:{j}";

            private class DataItem
            {
                public DataItem(int i, int j, int squareIndex)
                {
                    I = i;
                    J = j;
                    SquareIndex = squareIndex;
                }

                public int I { get; set; }

                public int J { get; set; }

                public int SquareIndex { get; set; }
            }
        }
    }
}