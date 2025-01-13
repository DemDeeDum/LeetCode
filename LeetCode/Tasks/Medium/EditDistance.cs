using System.Text;

namespace LeetCode.Tasks.Medium
{
    internal class EditDistance
    {
        public class Solution
        {
            public int MinDistance(string word1, string word2)
            {
                var memo = new Dictionary<(int, int, int), int>();

                return DP(word1, word1.Length, 0, 0, word2, memo);
            }

            private int DP(string source, int lengthS, int sourceIndex, int targetIndex, string target, Dictionary<(int, int ,int), int> memo)
            {
                if (memo.TryGetValue((lengthS, sourceIndex, targetIndex), out var value))
                {
                    return value;
                }

                var result = 0;

                if (targetIndex == target.Length)
                {
                    result = lengthS - target.Length;
                }
                else if (sourceIndex == source.Length)
                {
                    result = target.Length - targetIndex;
                }
                else if (source[sourceIndex] != target[targetIndex])
                {
                    var deleteApproach = DP(source, lengthS - 1, sourceIndex + 1, targetIndex, target, memo);
                    var replaceApproach = DP(source, lengthS, sourceIndex + 1, targetIndex + 1, target, memo);
                    var insertApproach = DP(source, lengthS + 1, sourceIndex, targetIndex + 1, target, memo);

                    result = 1 + Math.Min(Math.Min(deleteApproach, replaceApproach), insertApproach);
                }
                else
                {
                    result = DP(source, lengthS, sourceIndex + 1, targetIndex + 1, target, memo);
                }

                memo[(lengthS, sourceIndex, targetIndex)] = result;

                return result;
            }
        }
    }
}
