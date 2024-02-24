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
            private List<DataItem> solved;

            public void SolveSudoku(char[][] board)
            {
                solved = new List<DataItem>(board.Length * board[0].Length);
                var somethingChanges = true;
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

                    SetUpValues(board, coordinatesToSolvePerSquare[i], ref somethingChanges, Mode.Square);
                }

                while (coordinatesToSolvePerSquare.Any())
                {
                    foreach (var squareWithCoordinates in coordinatesToSolvePerSquare)
                    {
                        SetUpValues(board, squareWithCoordinates.Value, ref somethingChanges, Mode.Square);
                    }

                    foreach (var lineWithCoordinates in coordinatesToSolvePerLine)
                    {
                        SetUpValues(board, lineWithCoordinates.Value, ref somethingChanges, Mode.Line);
                    }

                    foreach (var columnWithCoordinates in coordinatesToSolvePerColumn)
                    {
                        SetUpValues(board, columnWithCoordinates.Value, ref somethingChanges, Mode.Column);
                    }
                }
            }

            private void SetUpValues(char[][] board, IList<DataItem> coordinatesToSolve, ref bool somethingChanges, Mode mode)
            {
                if (true)
                {
                    foreach (var item in coordinatesToSolve)
                    {
                        FindPositions(board, item.I, item.J, mode);
                    }
                }

                if (coordinatesToSolve.All(x => x.I == 8))
                {

                }

                somethingChanges = false;

                var values = coordinatesToSolve.Select(x => (Coordinates: x, Values: cache[GetKey(x.I, x.J)]));
                for (int i = 0; i < values.Count(); i++)
                {
                    var element = values.ElementAt(i);
                    var value = element.Values.FirstOrDefault();

                    if (value != default)
                    {
                        board[element.Coordinates.I][element.Coordinates.J] = value;

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

                        solved.Add(element.Coordinates);
                        somethingChanges = true;

                        foreach (var item in coordinatesToSolve)
                        {
                            FindPositions(board, item.I, item.J, mode);
                        }

                        Prind(board);
                    }
                }
            }

            private void FindPositions(char[][] board, int i, int j, Mode mode, int recursiveDeep = 0)
            {
                var possibleByLine = chars.Except(board[i]);
                var possibleByColumn = chars.Except(board.Select(x => x[j]));
                var possibleBySquare = chars.Except(coordinates[squareScheme[i][j]]
                    .Where(x => !(x.i == i && x.j == j) && board[x.i][x.j] != '.')
                    .Select(x => board[x.i][x.j]));

                var possibleValues = possibleBySquare.Intersect(possibleByColumn).Intersect(possibleByLine).ToList();
                if (!possibleValues.Any() && recursiveDeep < 81)
                {
                    var possibleForAlternative =
                        mode.Equals(Mode.Column)
                        ? possibleBySquare.Intersect(possibleByLine)
                        : mode.Equals(Mode.Line)
                        ? possibleBySquare.Intersect(possibleByColumn)
                        : possibleByLine.Intersect(possibleByColumn);

                    possibleValues = FindAlternatives(board, i, j, possibleForAlternative, mode, recursiveDeep + 1);
                }

                cache[GetKey(i, j)] = possibleValues;
            }
            /// <summary>
            /// 1) place which possible
            /// 2) if not find exchange recursively
            /// </summary>
            /// <param name="board"></param>
            /// <param name="iCoordinate"></param>
            /// <param name="jCoordinate"></param>
            /// <param name="otherPossible"></param>
            /// <param name="mode"></param>
            /// <param name="recursiveDeep"></param>
            /// <returns></returns>
            private List<char> FindAlternatives(char[][] board, int iCoordinate, int jCoordinate, IEnumerable<char> otherPossible, Mode mode, int recursiveDeep = 0)
            {
                var coordinatesToFindAlternativeFrom = mode == Mode.Line
                    ? solved.Where(x => x.I == iCoordinate)
                    : mode == Mode.Column
                    ? solved.Where(x => x.J == jCoordinate)
                    : solved.Where(y => coordinates[squareScheme[iCoordinate][jCoordinate]].Any(x => y.I == x.i && y.J == x.j));

                foreach (var element in coordinatesToFindAlternativeFrom)
                {
                    FindPositions(board, element.I, element.J, mode, recursiveDeep);
                }

                for (var i = 0; i < coordinatesToFindAlternativeFrom.Count(); i++)
                {
                    var element = coordinatesToFindAlternativeFrom.ElementAt(i);
                    var commonValue = otherPossible.FirstOrDefault(x => x == board[element.I][element.J]);
                    if (commonValue != default)
                    {
                        var elementPossibleValues = cache[GetKey(element.I, element.J)];
                        if (elementPossibleValues.Any())
                        {
                            board[element.I][element.J] = elementPossibleValues.First();

                            return new List<char> { commonValue };
                        }
                    }
                }

                return new List<char>();
            }

            private string GetKey(int i, int j) => $"{i}:{j}";

            private enum Mode
            {
                Line,
                Column,
                Square
            }

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

            private void Prind(char[][] board)
            {
                //Thread.Sleep(2000);
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("---------------------------------------------------------");
                for (var i = 0; i < board.Length; i++)
                {
                    for (var j = 0; j < board[i].Length; j++)
                    {
                        Console.Write($"{board[i][j]}\t");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
        }
    }
}