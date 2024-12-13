namespace LeetCode.Tasks.Easy
{
    internal class ValidParentheses
    {
        public class Solution
        {
            public bool IsValid(string s)
            {
                var opens = new Dictionary<char, int> { { '(', 1 }, { '[', 2 }, { '{', 3 } };
                var closes = new Dictionary<char, int> { { ')', 1 }, { ']', 2 }, { '}', 3 } };

                var i = 0;
                if (!opens.ContainsKey(s[i]))
                {
                    return false;
                }

                var indexStack = new Stack<int>();
                indexStack.Push(opens[s[i]]);
                for (i = 1; i < s.Length; i++)
                {
                    if (opens.ContainsKey(s[i]))
                    {
                        indexStack.Push(opens[s[i]]);
                    }
                    else if (closes.ContainsKey(s[i]))
                    {
                        if (indexStack.Count == 0 || indexStack.Peek() != closes[s[i]])
                        {
                            return false;
                        }
                        else
                        {
                            indexStack.Pop();
                        }
                    }
                }

                if (indexStack.Count > 0)
                {
                    return false;
                }

                return true;
            }
        }
    }
}
