namespace LeetCode.Tasks.Easy
{
    internal class RemoveElement
    {
        public class Solution
        {
            public int RemoveElement(int[] nums, int val)
            {
                if (nums.Length == 0)
                {
                    return 0;
                }

                var numberOfEntrance = 0;
                var frontIndex = 0;
                var backIndex = nums.Length - 1;

                while (frontIndex <= backIndex)
                {
                    if (nums[frontIndex] == val)
                    {
                        numberOfEntrance++;

                        if (!UpdateBackIndex(nums, frontIndex, ref backIndex, ref numberOfEntrance, val))
                        {
                            break;
                        }

                        nums[frontIndex] = nums[backIndex];
                        nums[backIndex] = val;

                        backIndex--;
                    }

                    frontIndex++;
                }

                UpdateBackIndex(nums, frontIndex, ref backIndex, ref numberOfEntrance, val);

                return nums.Length - numberOfEntrance;
            }

            private bool UpdateBackIndex(int[] nums, int frontIndex, ref int backIndex, ref int numberOfEntrance, int val)
            {
                while (backIndex >= 0 && frontIndex != backIndex && nums[backIndex] == val)
                {
                    numberOfEntrance++;
                    backIndex--;
                }

                return backIndex >= 0;
            }
        }
    }
}
