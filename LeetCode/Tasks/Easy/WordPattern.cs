namespace LeetCode.Tasks.Easy
{
    internal class WordPattern
    {
        public class Solution
        {
            public bool WordPattern(string pattern, string s)
            {
                var values = s.Split(' ');
                var data = new Dictionary<char, string>();
                if (values.Length != pattern.Length)
                {
                    return false;
                }

                for (var i = 0; i < pattern.Length; i++)
                {
                    if (data.ContainsKey(pattern[i]))
                    {
                        if (values[i] != data[pattern[i]])
                        {
                            return false;
                        }
                    }
                    else if (data.Values.Any(x => x == values[i]))
                    {
                        return false;
                    }
                    else
                    {
                        data.Add(pattern[i], values[i]);
                    }
                }

                return true;
            }
        }
    }
}
