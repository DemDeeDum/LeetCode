namespace LeetCode.Tasks.Easy
{
    internal class TwoSumToTarget
    {
        public class Solution
        {
            public int[] TwoSum(int[] nums, int target)
            {
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    var substraction = target - nums[i];
                    var index = Array.IndexOf(nums, substraction, i + 1);
                    if (index != -1)
                    {
                        return [i, index];
                    }
                }

                return [];
            }
        }
    }
}
