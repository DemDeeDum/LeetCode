namespace LeetCode.Tasks.Medium
{
    internal class IntegerToString
    {
        public class Solution
        {
            public int MyAtoi(string s)
            {
                var sign = true;
                int? number = null;
                foreach (var character in s)
                {
                    if (int.TryParse($"{character}", out var value))
                    {
                        if (number.HasValue)
                        {
                            number *= 10;
                            number += value;
                        }
                        else if (value != 0)
                        {
                            number = value;
                        }
                    }
                    else if (character == '-')
                    {
                        sign = !sign;
                    }
                    else if (!char.IsWhiteSpace(character))
                    {
                        break;
                    }
                }

                return number.GetValueOrDefault() * (sign ? 1 : -1);
            }
        }
    }
}
