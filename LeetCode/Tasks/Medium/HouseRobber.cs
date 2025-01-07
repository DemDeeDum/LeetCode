namespace LeetCode.Tasks.Medium
{
    class HouseRobber
    {
        public class Solution
        {
            private int[] Memo;
            public int Rob(int[] nums)
            {
                Memo = new int[nums.Length];
                Array.Fill(Memo, -1);

                return CalculateDP(nums, 0);
            }

            /// <summary>
            /// Recursion
            /// </summary>
            /// <param name="nums"></param>
            /// <param name="index"></param>
            /// <param name="total"></param>
            /// <returns></returns>
            public int CalculateDP(int[] nums, int index)
            {
                if (index >= nums.Length)
                {
                    return 0;
                }

                if (Memo[index] != -1)
                {
                    return Memo[index];
                }

                var resultOne = index + 2 >= nums.Length
                    ? nums[index]
                    : CalculateDP(nums, index + 4) + nums[index] + nums[index + 2];
                var resultTwo = index + 1 >= nums.Length
                    ? 0
                    : CalculateDP(nums, index + 3) + nums[index + 1];
                var resultThree = CalculateDP(nums, index + 3) + nums[index];

                Memo[index] = Math.Max(Math.Max(resultOne, resultTwo), resultThree);

                return Memo[index];
            }
        }
    }
}
