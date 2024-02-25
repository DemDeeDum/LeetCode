namespace LeetCode.Tasks.Medium
{
    internal class LongestConsecutiveSequence
    {
        public class Solution
        {
            public int LongestConsecutive(int[] nums)
            {
                if (nums.Length == 0)
                {
                    return 0;
                }

                Array.Sort(nums);
                var max = int.MinValue;
                var sum = 1;
                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] == nums[i - 1] + 1)
                    {
                        sum++;
                    }
                    else if (nums[i] != nums[i - 1])
                    {
                        max = Math.Max(max, sum);

                        sum = 1;
                    }
                }

                return Math.Max(max, sum);
            }
        }
    }
}
