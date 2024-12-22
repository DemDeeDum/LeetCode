using System.Text;

namespace LeetCode.Tasks.Easy
{
    internal class MergeStringsAlternately
    {
        public class Solution
        {
            public string MergeAlternately(string word1, string word2)
            {
                var indexOne = 0;
                var indexTwo = 0;
                var builder = new StringBuilder();
                var firstLessThanLength = indexOne < word1.Length;
                var secondLessThanLength = indexTwo < word2.Length;

                while (firstLessThanLength || secondLessThanLength)
                {
                    if (firstLessThanLength)
                    {
                        builder.Append(word1[indexOne++]);
                        firstLessThanLength = indexOne < word1.Length;
                    }

                    if (secondLessThanLength)
                    {
                        builder.Append(word2[indexTwo++]);
                        secondLessThanLength = indexTwo < word2.Length;
                    }
                }

                return builder.ToString();
            }
        }
    }
}
