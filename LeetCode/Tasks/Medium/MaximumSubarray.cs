namespace LeetCode.Tasks.Medium
{
    class MaximumSubarray
    {
        public class Solution
        {
            public int MaxSubArray(int[] nums)
            {
                var currentSum = 0;
                var bestSum = int.MinValue;
                foreach (var num in nums)
                {
                    currentSum = Math.Max(num, currentSum + num);
                    bestSum = Math.Max(currentSum, bestSum);
                }

                return bestSum;
            }
        }
    }
}
