namespace LeetCode.Tasks.Medium
{
    internal class ReverseTheWords
    {
        public class Solution
        {
            public string ReverseWords(string s)
            {
                return string.Join(' ', s.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Reverse());
            }
        }
    }
}
