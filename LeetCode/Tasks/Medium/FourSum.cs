namespace LeetCode.Tasks.Medium
{
    internal class ForSumTask
    {
        public class Solution
        {
            public IList<IList<int>> FourSum(int[] nums, int target)
            {
                var result = new List<IList<int>>();
                Array.Sort(nums);
                for (var i = 0; i < nums.Length; i++)
                {
                    if (i > 0 && nums[i] == nums[i - 1])
                    {
                        continue;
                    }

                    for (var j = i + 1; j < nums.Length; j++)
                    {
                        if (j != i + 1 && nums[j] == nums[j - 1])
                        {
                            continue;
                        }

                        for (var k = j + 1; k < nums.Length; k++)
                        {
                            if (k != j + 1 && nums[k] == nums[k - 1])
                            {
                                continue;
                            }

                            for (var l = k + 1; l < nums.Length; l++)
                            {
                                if (l != k + 1 && nums[l] == nums[l - 1])
                                {
                                    continue;
                                }

                                long sum = (long)nums[i] + (long)nums[j] + (long)nums[k] + (long)nums[l];
                                if (sum == target)
                                {
                                    result.Add(new List<int> { nums[i], nums[j], nums[k], nums[l] });
                                }
                            }
                        }
                    }
                }

                return result;
            }
        }
    }
}
