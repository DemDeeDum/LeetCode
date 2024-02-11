namespace LeetCode.Tasks.Hard
{
    internal class MinimumWindowSubstring
    {
        public class Solution
        {
            public string MinWindow(string s, string t)
            {
                var firstIndexMin = -1;
                var length = int.MaxValue;
                var data = t
                    .Select(x => new Indicator
                    {
                        Character = x,
                        Index = -1
                    })
                    .ToList();

                for (var i = 0; i < s.Length; i++)
                {
                    var elementIndex = data.FindIndex(x => x.Character == s[i]);
                    if (elementIndex != -1)
                    {
                        var previousIndexes = new List<int>((data.Count / 2) + 1) { elementIndex };

                        while (data[elementIndex].Index != -1 && elementIndex < data.Count - 1)
                        {
                            var temp = elementIndex;

                            elementIndex = data.FindIndex(elementIndex + 1, x => x.Character == s[i]);
                            if (elementIndex == -1)
                            {
                                elementIndex = temp;

                                break;
                            }

                            previousIndexes.Add(elementIndex);
                        }

                        if (data[elementIndex].Index == -1)
                        {
                            data[elementIndex].Index = i;

                            if (data.All(x => x.Index != -1))
                            {
                                var element = data.MinBy(x => x.Index);
                                var foundLength = i - element!.Index + 1;
                                if (length > foundLength)
                                {
                                    length = foundLength;
                                    firstIndexMin = element.Index;
                                }

                                element.Index = -1;
                            }
                        }
                        else
                        {
                            if (previousIndexes.Any())
                            {
                                previousIndexes.RemoveAt(previousIndexes.Count - 1);

                                if (previousIndexes.Any())
                                {
                                    for (var j = 0; j < previousIndexes.Count - 1; j++)
                                    {
                                        data[previousIndexes[j] + 1].Index = data[previousIndexes[j]].Index;
                                    }

                                    data[previousIndexes[0]].Index = data[elementIndex].Index;
                                }
                            }

                            data[elementIndex].Index = i;
                        }
                    }
                }

                return length.Equals(int.MaxValue) ? string.Empty : s.Substring(firstIndexMin, length);
            }

            private class Indicator
            {
                public char Character { get; set; }

                public int Index { get; set; }
            }
        }
    }
}
