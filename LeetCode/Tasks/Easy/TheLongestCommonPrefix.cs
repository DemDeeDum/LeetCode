using System.Text;

namespace LeetCode.Tasks.Easy
{
    internal class TheLongestCommonPrefix
    {
        public class Solution
        {
            public string LongestCommonPrefix(string[] strs)
            {
                var builder = new StringBuilder(strs[0]);
                var index = 0;
                for (var i = 1; i < strs.Length; i++)
                {
                    while (index < strs[i].Length && index < builder.Length && builder[index] == strs[i][index])
                    {
                        index++;
                    }

                    if (strs[i].Length < builder.Length || index < builder.Length)
                    {
                        builder.Remove(index, builder.Length - index);
                    }

                    if (builder.Length == 0)
                    {
                        return string.Empty;
                    }

                    index = 0;
                }

                return builder.ToString();
            }
        }
    }
}
