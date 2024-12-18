
namespace LeetCode.Tasks.Easy
{
    internal class ClimbingStairs
    {
        public class Solution
        {
            public int ClimbStairs(int n)
            {
                var a = 1;
                var b = 1;

                for (var i = 1; i < n; i++)
                {
                    b = a + b;
                    a = b - a;
                }

                return b;
            }
        }
    }
}
