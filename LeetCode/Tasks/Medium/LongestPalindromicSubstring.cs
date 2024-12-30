namespace LeetCode.Tasks.Medium
{
    internal class LongestPalindromicSubstring
    {
        public class Solution
        {
            public string LongestPalindrome(string s)
            {
                if (s.Length < 2)
                {
                    return s;
                }

                var memo = new bool[s.Length, s.Length];
                var maxI = 0;
                var maxJ = 0;

                for (var i = 0; i < s.Length; i++)
                {
                    for (var j = i - 1; j >= 0; j--)
                    {
                        if (s[j] == s[i])
                        {
                            memo[i, j] = i - j <= 2 || memo[i - 1, j + 1];
                            if (memo[i, j] && i - j > maxI - maxJ)
                            {
                                maxI = i;
                                maxJ = j;
                            }
                        }
                    }
                }

                return s.Substring(maxJ, maxI - maxJ + 1);
            }
        }
    }
}
