﻿using LeetCode.Tasks.Hard;

class Program
{
    /// <summary>
    /// Done by Dmytro Lozhka sometimes using friend's laptop
    /// </summary>
    public static void Main()
    {
        var a = new SudokuSolver.Solution();
        var d = new char[][]
        {
            new char[] { '5','3','.','.','7','.','.','.','.' },
            new char[] { '6','.','.','1','9','5','.','.','.'},
            new char[] { '.','9','8','.','.','.','.','6','.' },
            new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
            new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
            new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
            new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
            new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
            new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
        };
        a.SolveSudoku(d);
    }
}