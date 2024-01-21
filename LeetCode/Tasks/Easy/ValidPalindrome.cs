namespace LeetCode.Tasks.Easy
{
    internal class ValidPalindrome
    {
        public class Solution
        {
            public bool IsPalindrome(string s)
            {
                var cleaned = s.Where(x => char.IsLetterOrDigit(x)).Select(x => char.ToLower(x));

                return cleaned.SequenceEqual(cleaned.Reverse());
            }
        }
    }
}
