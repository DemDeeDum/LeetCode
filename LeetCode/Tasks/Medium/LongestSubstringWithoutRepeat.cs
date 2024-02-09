namespace LeetCode.Tasks.Medium
{
    internal class LongestSubstringWithoutRepeat
    {
        public class Solution
        {
            public int LengthOfLongestSubstring(string s)
            {
                var max = int.MinValue;
                var count = 0;
                var arrayIndex = 0;
                var array = new char[s.Length];
                var alreadySubstracted = 0;
                var lastStart = 0;
                foreach (char character in s)
                {
                    var index = Array.IndexOf(array, character, lastStart);
                    if (index != -1)
                    {
                        if (count > max)
                        {
                            max = count;
                        }

                        count -= index + 1 - alreadySubstracted;
                        alreadySubstracted = index + 1;
                        lastStart = index + 1;
                    }

                    array[arrayIndex++] = character;
                    count++;
                }

                if (count > max)
                {
                    max = count;
                }

                return max;
            }
        }
    }
}
