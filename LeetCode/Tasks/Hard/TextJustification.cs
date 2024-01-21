using System;
using System.Text;

namespace LeetCode.Tasks.Hard
{
    internal class TextJustification
    {
        public class Solution
        {
            private const string Separator = " ";

            public IList<string> FullJustify(string[] words, int maxWidth)
            {
                var list = new List<string>();
                var stringBuilder = new StringBuilder();
                var lastPositionsOfWords = new List<int>(60);
                for (var i = 0; i < words.Length; i++)
                {
                    if (stringBuilder.Length + words[i].Length > maxWidth)
                    {
                        CommitLine(stringBuilder, lastPositionsOfWords, maxWidth, list, false);
                    }

                    stringBuilder.Append(words[i]);
                    lastPositionsOfWords.Add(stringBuilder.Length - 1);
                    stringBuilder.Append(Separator);
                }

                if (stringBuilder.Length > 0)
                {
                    CommitLine(stringBuilder, lastPositionsOfWords, maxWidth, list, true);
                }

                return list;
            }

            private void CommitLine(StringBuilder stringBuilder, List<int> lastPositionsOfWords, int maxWidth, IList<string> list, bool last)
            {
                AddSpacesBetween(stringBuilder, lastPositionsOfWords, maxWidth, last);
                list.Add(stringBuilder.ToString());
                stringBuilder.Clear();
                lastPositionsOfWords.Clear();
            }

            private void AddSpacesBetween(StringBuilder stringBuilder, List<int> lastPositionsOfWords, int maxWidth, bool last)
            {
                if (!last)
                {
                    lastPositionsOfWords.RemoveAt(lastPositionsOfWords.Count - 1);
                }

                stringBuilder.Remove(stringBuilder.Length - 1, 1);
                var numberOfSpacesToAdd = maxWidth - stringBuilder.Length;
                if (!lastPositionsOfWords.Any() || last)
                {
                    stringBuilder.Append(new string(' ', numberOfSpacesToAdd));

                    return;
                }

                var numberOfSpacesCannotBeDivided = numberOfSpacesToAdd % lastPositionsOfWords.Count;
                var numberOfSpacesDividedByWord = numberOfSpacesToAdd / lastPositionsOfWords.Count;
                for (var index = 0; index < lastPositionsOfWords.Count; index++)
                {
                    stringBuilder.Insert(lastPositionsOfWords[index] + 1, Separator, numberOfSpacesDividedByWord);
                    for (var j = index + 1; j < lastPositionsOfWords.Count; j++)
                    {
                        lastPositionsOfWords[j] += numberOfSpacesDividedByWord;
                    }
                }

                for (var i = 0; i < numberOfSpacesCannotBeDivided; i++)
                {
                    stringBuilder.Insert(lastPositionsOfWords[i] + 1, Separator);
                    for (var j = i + 1; j < lastPositionsOfWords.Count; j++)
                    {
                        lastPositionsOfWords[j]++;
                    }
                }
            }
        }
    }
}
