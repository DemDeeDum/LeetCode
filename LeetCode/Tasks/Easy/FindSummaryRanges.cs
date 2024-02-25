namespace LeetCode.Tasks.Easy
{
    internal class FindSummaryRanges
    {
        public class Solution
        {
            public IList<string> SummaryRanges(int[] nums)
            {
                var ranges = new List<string>();
                if (nums.Length == 0)
                {
                    return ranges;
                }

                var startIndex = 0;
                for (var i = 1; i < nums.Length; i++)
                {
                    if (nums[i] != nums[i - 1] + 1)
                    {
                        if (i - startIndex == 1)
                        {
                            ranges.Add(GetRange(nums[startIndex]));
                        }
                        else
                        {
                            ranges.Add(GetRange(nums[startIndex], nums[i - 1]));
                        }

                        startIndex = i;
                    }
                }

                if (startIndex == nums.Length - 1)
                {
                    ranges.Add(GetRange(nums[startIndex]));
                }
                else
                {
                    ranges.Add(GetRange(nums[startIndex], nums[nums.Length - 1]));
                }

                return ranges;
            }

            private string GetRange(int start, int? end = null) => end.HasValue ? $"{start}->{end}" : start.ToString();
        }
    }
}
