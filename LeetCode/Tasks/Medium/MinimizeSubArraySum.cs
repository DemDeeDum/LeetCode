namespace LeetCode.Tasks.Medium
{
    internal class MinimizeSubArraySum
    {
        public class Solution
        {
            public int MinSubArrayLen(int target, int[] nums)
            {
                var result = int.MaxValue;
                var initialSum = 0;
                var initialCounter = 0;
                var index = -1;
                while (initialCounter + index++ < nums.Length)
                {
                    var resultOfSteps = GetStepsToTarget(nums, index + initialCounter, target, result, ref initialSum, ref initialCounter);
                    if (resultOfSteps.Result)
                    {
                        initialCounter++;
                        var j = index;
                        index--;
                        while (initialSum >= target)
                        {
                            initialSum -= nums[j++];
                            initialCounter--;
                            index++;
                        }

                        result = initialCounter;
                        initialCounter--;
                    }
                    else
                    {
                        initialCounter -= initialCounter == 0 ? 0 : 1;
                        initialSum -= initialSum == 0 ? 0 : 1;
                    }

                    if (resultOfSteps.ShouldStop)
                    {
                        break;
                    }
                }

                return result == int.MaxValue ? 0 : result;
            }

            private (bool Result, bool ShouldStop) GetStepsToTarget(int[] nums, int index, int target, int prevMin, ref int sum, ref int counter)
            {
                var localSum = sum;
                var localCounter = counter;
                while (index < nums.Length && localSum < target && localCounter < prevMin)
                {
                    localSum += nums[index++];
                    localCounter++;
                }

                if (localSum < target)
                {
                    return (false, true);
                }

                if (localCounter > prevMin)
                {
                    return (false, false);
                }

                counter = localCounter;
                sum = localSum;

                if (counter == 1)
                {
                    return (true, true);
                }

                return (true, false);
            }
        }
    }
}
