namespace LeetCode.Tasks.Medium
{
    public class ProductOfArrayExceptSelf
    {
        public class Solution
        {
            public int[] ProductExceptSelf(int[] nums)
            {
                var result = new int[nums.Length];
                var countOfZeros = 0;
                var total = nums.Aggregate((x, y) =>
                {
                    var xZero = x == 0;
                    var yZero = y == 0;
                    
                    if (xZero && yZero)
                    {
                        countOfZeros += 2;

                        return 1;
                    }
                    else if (xZero || yZero)
                    {
                        countOfZeros += 1;
                    }

                    return xZero
                        ? y
                        : yZero
                        ? x
                        : x * y;

                });

                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] == 0)
                    {
                        result[i] = countOfZeros > 1 ? 0 : total;
                    }
                    else if (countOfZeros > 0)
                    {
                        result[i] = 0;
                    }
                    else
                    {
                        result[i] = total / nums[i];
                    }
                }

                return result;
            }
        }
    }
}
