namespace LeetCode.Tasks.Medium
{
    internal class EqualSumArraysWithMinimumOperations
    {
        public class Solution
        {
            public int MinOperations(int[] nums1, int[] nums2)
            {
                var sum1 = nums1.Sum();
                var sum2 = nums2.Sum();
                var difference = sum1 - sum2;
                if (difference == 0)
                {
                    return 0;
                }

                var numberOfOperationsNeeded = 0;
                int[] greater;
                int[] smaller;
                int sumGreater;
                int sumSmaller;
                Array.Sort(nums1);
                Array.Sort(nums2);
                if (difference > 0)
                {
                    greater = nums1;
                    sumGreater = sum1;
                    smaller = nums2;
                    sumSmaller = sum2;
                }
                else
                {
                    greater = nums2;
                    sumGreater = sum2;
                    smaller = nums1;
                    sumSmaller = sum1;
                }

                var indexSmaller = 0;
                var indexGreater = greater.Length - 1;
                var canSearchSmaller = indexSmaller < smaller.Length;
                var canSearchGreater = indexGreater >= 0;
                var differenceFixed = false;
                difference = Math.Abs(difference);
                while (canSearchSmaller || canSearchGreater)
                {
                    var differenceSmaller = 6 - (canSearchSmaller ? smaller[indexSmaller] : 7);
                    var differenceGreater = (canSearchGreater ? greater[indexGreater] : 0) - 1;
                    if (differenceSmaller == 0 && differenceGreater == 0)
                    {
                        break;
                    }

                    if (differenceSmaller > differenceGreater)
                    {
                        difference -= differenceSmaller;
                        indexSmaller++;
                        canSearchSmaller = indexSmaller < smaller.Length;
                    }
                    else
                    {
                        difference -= differenceGreater;
                        indexGreater--;
                        canSearchGreater = indexGreater >= 0;
                    }

                    numberOfOperationsNeeded++;
                    if (difference <= 0)
                    {
                        differenceFixed = true;

                        break;
                    }
                }

                if (!differenceFixed)
                {
                    numberOfOperationsNeeded = -1;
                }

                return numberOfOperationsNeeded;
            }
        }
    }
}
