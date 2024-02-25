namespace LeetCode.Tasks.Easy
{
    internal class ValidAnagram
    {
        public class Solution
        {
            public bool IsAnagram(string s, string t)
            {
                if (s.Length != t.Length)
                {
                    return false;
                }

                var dictionaryS = new int[26];
                var dictionaryT = new int[26];
                for (int i = 0; i < s.Length; i++)
                {
                    dictionaryS[s[i] - 97]++;
                    dictionaryT[t[i] - 97]++;
                }

                for (var i = 0; i < dictionaryS.Length; i++)
                {
                    if (dictionaryS[i] != dictionaryT[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}