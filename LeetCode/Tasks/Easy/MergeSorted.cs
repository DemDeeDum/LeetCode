namespace LeetCode.Tasks.Easy
{
    internal class MergeSorted
    {
        public class Solution
        {
            public void Merge(int[] nums1, int m, int[] nums2, int n)
            {
                var firstIndex = 0;
                var secondIndex = 0;
                var finalIndex = 0;
                var finalArray = new int[n + m];
                while (finalIndex < n + m)
                {
                    if (firstIndex < m && (secondIndex >= n || nums1[firstIndex] < nums2[secondIndex]))
                    {
                        finalArray[finalIndex] = nums1[firstIndex++];
                    }
                    else
                    {
                        finalArray[finalIndex] = nums2[secondIndex++];
                    }

                    finalIndex++;
                }

                finalArray.CopyTo(nums1, 0);
            }
        }
    }
}
