namespace LeetCode.Tasks.Easy
{
    internal class ContainsDuplicateTwo
    {
        public class Solution
        {
            public bool ContainsNearbyDuplicate(int[] nums, int k)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = 1; j <= k && i + j < nums.Length; j++)
                    {
                        if (nums[i] == nums[i + j])
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }
    }
}
