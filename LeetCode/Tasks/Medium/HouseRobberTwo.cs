namespace LeetCode.Tasks.Medium
{
    public class HouseRobberTwo
    {
        public class Solution
        {
            private Dictionary<(int, bool), int> Memo = new Dictionary<(int, bool), int>();
            public int Rob(int[] nums)
            {
                return DPRob(0, nums, false, true);
            }

            public int DPRob(int index, int[] nums, bool veryFirstIncluded, bool setVeryFirst = false)
            {
                if (setVeryFirst)
                {
                    veryFirstIncluded = index == 0;
                }

                if (Memo.TryGetValue((index, veryFirstIncluded), out var value))
                {
                    return value;
                }

                if (index >= nums.Length)
                {
                    return 0;
                }

                if (veryFirstIncluded && index == nums.Length - 1)
                {
                    return nums.Length == 1
                        ? nums[index]
                        : nums[index] - nums[0] > 0
                        ? nums[index] - nums[0]
                        : 0;
                }

                var resultOne = nums[index] + DPRob(index + 2, nums, veryFirstIncluded);
                var next = index + 1;

                if (setVeryFirst)
                {
                    veryFirstIncluded = false;
                }

                var resultTwo = next < nums.Length
                    ? next == nums.Length - 1
                    ? veryFirstIncluded
                    ? nums[next] > nums[0] ? nums[next] - nums[0] : 0
                    : nums[next]
                    : nums[next] + DPRob(index + 3, nums, veryFirstIncluded)
                    : 0;

                var max = Math.Max(resultTwo, resultOne);
                Memo[(index, veryFirstIncluded)] = max;

                return Memo[(index, veryFirstIncluded)];
            }
        }
    }
}
