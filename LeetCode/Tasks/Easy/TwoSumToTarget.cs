namespace LeetCode.Tasks.Easy
{
    internal class TwoSumToTarget
    {
        public class Solution
        {
            public int[] TwoSum(int[] nums, int target)
            {
                var options = new List<int?>(nums.Length);
                for (int i = 0; i < nums.Length; i++)
                {
                    var subtraction = target - nums[i];
                    var index = options.FirstOrDefault(x => nums[x.Value] == subtraction);
                    if (index.HasValue)
                    {
                        return [index.Value, i];
                    }

                    options.Add(i);
                }

                return [];
            }
        }
    }
}
