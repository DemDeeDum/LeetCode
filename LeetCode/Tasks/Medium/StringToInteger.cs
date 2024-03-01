namespace LeetCode.Tasks.Medium
{
    internal class StringToInteger
    {
        public class Solution
        {
            public int MyAtoi(string s)
            {
                var numberOfDigitsAfterDote = 0;
                bool dote = false;
                bool? sign = null;
                int? number = null;
                var firstNumberFound = false;
                var numberOfDigits = 0;
                var nonDigitFound = false;
                foreach (var character in s)
                {
                    if (int.TryParse($"{character}", out var value))
                    {
                        firstNumberFound = true;
                        if (nonDigitFound)
                        {
                            return 0;
                        }
                        else if (numberOfDigits == 9)
                        {
                            if ((long)number! * 10 > 2147483647L)
                            {
                                return GetSignValue(sign) ? int.MaxValue : int.MinValue;
                            }
                            else if (number == 214748364 &&
                                (GetSignValue(sign) && value > 7
                                || !GetSignValue(sign) && value > 8))
                            {
                                return GetSignValue(sign) ? int.MaxValue : int.MinValue;
                            }
                        }
                        else if (numberOfDigits == 10)
                        {
                            return GetSignValue(sign) ? int.MaxValue : int.MinValue;
                        }

                        if (number.HasValue)
                        {
                            if (dote)
                            {
                                numberOfDigitsAfterDote++;
                                number += value / (int)Math.Pow(10, numberOfDigitsAfterDote);
                            }
                            else
                            {
                                number *= 10;
                                number += value;
                            }
                        }
                        else if (value != 0)
                        {
                            number = value;
                        }

                        if (number.HasValue)
                        {
                            numberOfDigits++;
                        }
                    }
                    else if (character == '-')
                    {
                        if (sign.HasValue || firstNumberFound)
                        {
                            break;
                        }

                        sign = false;
                    }
                    else if (character == '+')
                    {
                        if (sign.HasValue || firstNumberFound)
                        {
                            break;
                        }

                        sign = true;
                    }
                    else if (char.IsWhiteSpace(character) && (firstNumberFound || !sign.HasValue && firstNumberFound))
                    {
                        break;
                    }
                    else if (character == '.')
                    {
                        dote = true;
                        if (!firstNumberFound)
                        {
                            return 0;
                        }
                    }
                    else if (char.IsLetter(character))
                    {
                        if (!firstNumberFound)
                        {
                            return 0;
                        }

                        break;
                    }
                }

                return number.GetValueOrDefault() * (GetSignValue(sign) ? 1 : -1);
            }

            private bool GetSignValue(bool? sign) => sign ?? true;
        }
    }
}
