using LeetCode.Tasks.Easy;
using LeetCode.Tasks.Hard;
using LeetCode.Tasks.Medium;
using Node = LeetCode.Tasks.Medium.CopyListWithRandomPointer.Node;

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

        //var a = new IntegerToEnglishWords.Solution();
        //while (true)
        //{
        //    Console.Write("Enter the number: ");
        //    var input = Console.ReadLine();
        //    if (string.IsNullOrWhiteSpace(input))
        //    {
        //        Console.WriteLine($"{Environment.NewLine} I SAID ENTER THE NUMBER");
        //    }
        //    else if (decimal.TryParse(input, out decimal number))
        //    {
        //        Console.WriteLine($"{Environment.NewLine} Here is your number => {a.NumberToWords(number)}");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"{Environment.NewLine} IT IS NOT A NUMBER");
        //    }
        //}


        var a = new LongestPalindromicSubstring.Solution();
        var s = a.ReverseKGroup(new ReverseNodesInKGroup.ListNode(1, new ReverseNodesInKGroup.ListNode(2, new ReverseNodesInKGroup.ListNode(3, new ReverseNodesInKGroup.ListNode(4, new ReverseNodesInKGroup.ListNode(5))))), 3);
    }
}   