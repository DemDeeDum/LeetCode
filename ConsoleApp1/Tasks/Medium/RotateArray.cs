namespace LeetCode.Tasks.Medium
{
    internal class RotateArray
    {
        public class Solution
        {
            public void Rotate(int[] nums, int k)
            {
                var shift =  k % nums.Length;
                var array = new int[shift];
                for (int i = nums.Length - shift, j = 0; i < nums.Length; j++, i++)
                {
                    array[j] = nums[i];
                }

                for (var i = nums.Length - 1; i >= shift; i--)
                {
                    nums[i] = nums[i - shift];
                }

                for (var i = 0; i < shift; i++)
                {
                    nums[i] = array[i];
                }
            }
        }
    }
}
