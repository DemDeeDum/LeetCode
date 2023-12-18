using System.Collections.Generic;

namespace LeetCode.Tasks.Medium
{
    internal class JumpGame
    {
        public class Solution
        {
            public bool CanJump(int[] nums)
            {
                var failedWays = new List<int>();
                var indexesToJump = new Stack<int>();
                indexesToJump.Push(nums.Length - 1);
                for (var i = nums.Length - 2; i >= 0; i--)
                {
                    if (nums[i] >= indexesToJump.Peek() - i
                        && !failedWays.Contains(i))
                    {
                        if (i == 0)
                        {
                            return true;
                        }

                        indexesToJump.Push(i);
                    }
                    else if (i == 0)
                    {
                        var failedWay = indexesToJump.Pop();
                        if (failedWay == nums.Length - 1)
                        {
                            break;
                        }

                        failedWays.Add(failedWay);
                        i = indexesToJump.Peek() - 1;
                    }
                }

                return false;
            }
        }
    }
}
