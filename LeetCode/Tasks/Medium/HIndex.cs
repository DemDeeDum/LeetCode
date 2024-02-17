namespace LeetCode.Tasks.Medium
{
    public class HIndex
    {
        public class Solution
        {
            public int HIndex(int[] citations)
            {
                var hIndex = 0;
                Array.Sort(citations);
                for (var i = 0; i < citations.Length; i++)
                {
                    hIndex = Math.Max(hIndex, Math.Min(citations[i], citations.Length - i));
                }

                return hIndex;
            }
        }
    }
}