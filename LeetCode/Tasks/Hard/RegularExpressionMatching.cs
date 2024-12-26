using System;

namespace LeetCode.Tasks.Hard
{
    internal class RegularExpressionMatching
    {
        public class Solution
        {
            const char Star = '*';
            const char Dote = '.';
            const char UpperDote = '!';

            public bool IsMatch(string s, string p)
            {
                var altSize = 0;
                var translated = new char[p.Length];
                for (var i = 0; i < p.Length; i++)
                {
                    if (p[i] != Star)
                    {
                        if (i < p.Length - 1 && p[i + 1] == Star)
                        {
                            translated[altSize++] = p[i] == Dote ? char.ToUpper(p[i]) : UpperDote;
                        }
                        else
                        {
                            translated[altSize++] = p[i];
                        }
                    }
                }

                var indexS = 0;
                var indexTranslated = 0;
                while (indexS < s.Length && indexTranslated < altSize)
                {
                    if (IsWildcard(translated[indexTranslated]))
                    {

                    }
                }

                return true;
            }

            private bool IsWildcard(char character)
            {
                return char.IsUpper(character) || character == UpperDote;
            }
        }
    }
}
