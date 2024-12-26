using System.Text;

namespace LeetCode.Tasks.Medium
{
    internal class GenerateParentheses
    {
        public class Solution
        {
            const char Left = '(';
            const char Right = ')';

            public IList<string> GenerateParenthesis(int n)
            {
                var builder = new StringBuilder();
                var list = new List<string>();
                var stack = new Stack<char>();
                BuildAllGenerations(n, string.Empty, 0, 0, list);

                return list;
            }

            private void BuildAllGenerations(int n, string value, int open, int closed, List<string> list)
            {
                if (value.Length == n * 2)
                {
                    list.Add(value);

                    return;
                }

                if (open < n)
                {
                    BuildAllGenerations(n, $"{value}{Left}", open + 1, closed, list);
                }

                if (closed < open)
                {
                    BuildAllGenerations(n, $"{value}{Right}", open, closed + 1, list);
                }
            }
        }
    }
}
