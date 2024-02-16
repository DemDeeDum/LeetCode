using LeetCode.Tasks.Medium;

class Program
{
    /// <summary>
    /// Done by Dmytro Lozhka sometimes using friend's laptop
    /// </summary>
    public static void Main()
    {
        var a = new SpiralMatrix.Solution();
        var c2 = a.SpiralOrder(new int[][]
        {
            new int[] { 1,11},
            new int[] { 2,12},
            new int[] { 3,13},
            new int[] { 4,14},
            new int[] { 5,15},
            new int[] { 6,16},
            new int[] { 7,17},
            new int[] { 8,18},
            new int[] { 9,19},
            new int[] { 10, 20 }
        });
    }
}