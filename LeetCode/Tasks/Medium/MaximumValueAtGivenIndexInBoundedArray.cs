namespace LeetCode.Tasks.Medium
{
    internal class MaximumValueAtGivenIndexInBoundedArray
    {
        public class Solution
        {
            public int MaxValue(int n, int index, int maxSum)
            {
                var min = 1;
                var max = maxSum;
                var center = 0;
                while (min < max)
                {
                    center = (min + max + 1) / 2;
                    if (GetSum(index, center, n) > maxSum)
                    {
                        max = center - 1;
                    }
                    else
                    {
                        min = center;
                    }
                }

                return min;
            }

            private long GetSum(int index, int someValue, int n)
            {
                long totalSum = 0;
                if (index < someValue)
                {
                    totalSum += (long)(someValue + someValue - index) * (index + 1) / 2;
                }
                else
                {
                    totalSum += (long)(someValue + 1) * someValue / 2 + index - someValue + 1;
                }

                if (someValue >= n - index)
                {
                    totalSum += (long)(someValue + someValue - n + 1 + index) * (n - index) / 2;
                }
                else
                {
                    totalSum += (long)(someValue + 1) * someValue / 2 + n - someValue - index;
                }

                return totalSum - someValue;
            }
        }
    }
}
