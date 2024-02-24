namespace LeetCode.Tasks.Easy
{
    internal class IsomorphicStrings
    {
        public class Solution
        {
            public bool IsIsomorphic(string s, string t)
            {
                var data = new Dictionary<char, char>();
                for (int i = 0; i < s.Length; i++)
                {
                    if (data.ContainsKey(s[i]))
                    {
                        if (data[s[i]] != t[i])
                        {
                            return false;
                        }
                    }
                    else if (data.Values.Contains(t[i]))
                    {
                        return false;
                    }
                    else
                    {
                        data.Add(s[i], t[i]);
                    }
                }

                return true;
            }
        }
    }
}
