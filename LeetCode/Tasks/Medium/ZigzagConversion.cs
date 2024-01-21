using System.Text;

namespace LeetCode.Tasks.Medium
{
    public class ZigzagConversion
    {
        public class Solution
        {
            public string Convert(string s, int numRows)
            {
                var builder = new StringBuilder();
                for(var i = 1; i <= numRows; i++)
                {
                    var iteration = 0;
                    for (var j = i - 1; j < s.Length; iteration++)
                    {
                        builder.Append(s[j]);
                        j += (int)(2 * (i == numRows || i == 1 ? Math.Max(numRows - 1, 0.5) : iteration % 2 == 0 ? Math.Max(numRows - i, 0.5) : i - 1));
                    }
                }

                return builder.ToString();
            }
        }
    }
}
