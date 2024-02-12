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
                var data = new Dictionary<char, List<int>>();
                foreach (var character in t.Distinct())
                {
                    data.Add(character, Enumerable.Repeat(-1, t.Count(x => x.Equals(character))).ToList());
                }

                for (var i = 0; i < s.Length; i++)
                {
                    if (data.TryGetValue(s[i], out var list))
                    {
                        var notFoundElementIndex = list.FindIndex(x => x == -1);
                        if (notFoundElementIndex != -1)
                        {
                            list[notFoundElementIndex] = i;

                            if (CheckIfEverythingFoundAndFirstIndex(data, out var listWithFirstIndex))
                            {
                                TryUpdateMin(i, ref length, ref firstIndexMin, listWithFirstIndex!);
                            }
                        }
                        else
                        {
                            for (var j = 0; j < list.Count - 1; j++)
                            {
                                list[j] = list[j + 1];
                            }

                            list[list.Count - 1] = i;

                            if (CheckIfEverythingFoundAndFirstIndex(data, out var listWithFirstIndex))
                            {
                                TryUpdateMin(i, ref length, ref firstIndexMin, listWithFirstIndex!);
                            }
                        }
                    }
                }

                return length.Equals(int.MaxValue) ? string.Empty : s.Substring(firstIndexMin, length);
            }

            public void TryUpdateMin(int i, ref int length, ref int firstIndexMin, List<int> list)
            {
                var foundLength = i - list[0] + 1;
                if (length > foundLength)
                {
                    length = foundLength;
                    firstIndexMin = list[0];
                }

                for (var j = 0; j < list.Count - 1; j++)
                {
                    list[j] = list[j + 1];
                }

                list[list.Count - 1] = -1;
            }

            private bool CheckIfEverythingFoundAndFirstIndex(Dictionary<char, List<int>> data, out List<int>? list)
            {
                list = null;
                var value = int.MaxValue;
                foreach (var pair in data)
                {
                    if (pair.Value[pair.Value.Count - 1] == -1)
                    {
                        return false;
                    }
                    else if (pair.Value[0] < value)
                    {
                        list = pair.Value;
                        value = pair.Value[0];
                    }
                }

                return true;
            }
        }
    }
}
