namespace LeetCode.Tasks.Medium
{
    public class ProductOfArrayExceptSelf
    {
        public class Solution
        {
            public int[] ProductExceptSelf(int[] nums)
            {
                var result = new int[nums.Length];
                for (int i = 0; i < nums.Length; i++)
                {
                    var skipped = false;
                    result[i] = nums.Aggregate((x, y) =>
                    {
                        if (!skipped)
                        {
                            if (y == nums[i])
                            {
                                skipped = true;

                                return x;
                            }
                            else if(i == 0 && nums[i] == x)
                            {
                                skipped = true;

                                return y;
                            }
                        }

                        return x * y;
                    });
                }

                return result;
            }
        }
    }
}
