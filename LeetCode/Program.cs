using LeetCode.Tasks.Hard;
using LeetCode.Tasks.Medium;

class Program
{
    /// <summary>
    /// Done by Dmytro Lozhka sometimes using friend's laptop
    /// </summary>
    public static void Main()
    {
        var a = new TrappingRainWater.Solution();
        //var c = a.Trap(new[] { 4, 0, 3, 0, 2, 0, 1 });
        var c = a.Trap(new[] { 4, 2, 0, 3, 2, 5 });
        //var c = a.Trap(new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });
    }
}