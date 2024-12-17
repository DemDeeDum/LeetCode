using LeetCode.Tasks.Easy;
using LeetCode.Tasks.Hard;
using LeetCode.Tasks.Medium;

class Program
{
    /// <summary>
    /// Done by Dmytro Lozhka sometimes using friend's laptop
    /// </summary>
    public static void Main()
    {
        //var a = new SudokuSolver.Solution();
        //var d = new char[][]
        //{
        //    new char[] { '5','3','.','.','7','.','.','.','.' },
        //    new char[] { '6','.','.','1','9','5','.','.','.'},
        //    new char[] { '.','9','8','.','.','.','.','6','.' },
        //    new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
        //    new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
        //    new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
        //    new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
        //    new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
        //    new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
        //};

        //var d2 = new char[][]
        //{
        //    new char[] { '.','.','9','7','4','8','.','.','.' },
        //    new char[] { '7','.','.','.','.','.','.','.','.'},
        //    new char[] {  '.','2','.','1','.','9','.','.','.' },
        //    new char[] { '.','.','7','.','.','.','2','4','.' },
        //    new char[] { '.','6','4','.','1','.','5','9','.' },
        //    new char[] { '.','9','8','.','.','.','3','.','.' },
        //    new char[] { '.','.','.','8','.','3','.','2','.' },
        //    new char[] { '.','.','.','.','.','.','.','.','6' },
        //    new char[] { '.', '.', '.', '2', '7', '5', '9', '.', '.' }
        //};
        //a.SolveSudoku(d2);

        int[][] c = [[0, 1, 0], [0, 0, 1], [1, 1, 1], [0, 0, 0]];
        var a = new MedianOfTwoSortedArrays.Solution();
        var s = a.FindMedianSortedArrays([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22], [0, 6]);
    }
}   