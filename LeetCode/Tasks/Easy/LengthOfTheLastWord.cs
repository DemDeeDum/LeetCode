namespace LeetCode.Tasks.Easy
{
    internal class LengthOfTheLastWord
    {
        public class Solution
        {
            public int LengthOfLastWord(string s)
            {
                return s.Split(' ').Last(x => !string.IsNullOrWhiteSpace(x)).Length;
            }
        }
    }
}
