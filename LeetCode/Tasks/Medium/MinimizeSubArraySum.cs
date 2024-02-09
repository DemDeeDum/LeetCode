namespace LeetCode.Tasks.Medium
{
    internal class MinimizeSubArraySum
    {
        public class Solution
        {
            public int MinSubArrayLen(int target, int[] nums)
            {
                var length = int.MaxValue;
                var initialSum = 0;
                var initialCounter = 0;
                var index = 0;
                while (initialCounter + index < nums.Length)
                {
                    var result = GetStepsToTarget(nums, index + initialCounter, target, length, ref initialSum, ref initialCounter);
                    if (result.InstantReturn)
                    {
                        break;
                    }

                    while (initialSum >= target)
                    {
                        initialSum -= nums[index++];
                        initialCounter--;
                    }

                    length = Math.Min(length, initialCounter + 1);

                    if (result.AssignThenReturn)
                    {
                        break;
                    }
                }

                return length == int.MaxValue ? 0 : length;
            }

            private (bool InstantReturn, bool AssignThenReturn) GetStepsToTarget(int[] nums, int index, int target, int prevMin, ref int sum, ref int counter)
            {
                var localSum = sum;
                var localCounter = counter;
                while (index < nums.Length && localSum < target)
                {
                    localSum += nums[index++];
                    localCounter++;
                }

                if (index == nums.Length && localSum < target)
                {
                    return (true, false);
                }
                counter = localCounter;
                sum = localSum;

                if (counter == 1)
                {
                    return (false, true);
                }

                return (false, false);
            }
        }
    }
}
