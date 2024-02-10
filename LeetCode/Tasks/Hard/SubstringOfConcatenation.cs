using System.Text;

namespace LeetCode.Tasks.Hard
{
    internal class SubstringOfConcatenation
    {
        public class Solution
        {
            public IList<int> FindSubstring(string s, string[] words)
            {
                var length = words.First().Length;
                var totalLength = words.Length * length;
                var indexes = new List<int>(words.Length / 2);
                var buffer = new StringBuilder();
                var data = Enumerable.Range(0, length)
                    .Select(x => (x, words.Select(x => new DataItem { Found = false, Word = x })
                    .ToList()))
                    .ToDictionary(x => x.x, x => x.Item2);

                for (var i = 0; i < s.Length; i++)
                {
                    buffer.Append(s[i]);
                    if (buffer.Length >= length)
                    {
                        var builderToString = buffer.ToString();
                        var currentList = data[i % length];
                        var indexOfItem = currentList.FindIndex(x => x.Word.Equals(builderToString));
                        if (indexOfItem != -1)
                        {
                            while (currentList[indexOfItem].Found && indexOfItem < currentList.Count - 1)
                            {
                                var temp = indexOfItem;
                                indexOfItem = currentList.FindIndex(indexOfItem + 1, x => x.Word.Equals(builderToString) && !x.Found);

                                if (indexOfItem == -1)
                                {
                                    indexOfItem = currentList.FindLastIndex(x => x.Word.Equals(builderToString) && x.Found);

                                    break;
                                }
                            }

                            if (!currentList[indexOfItem].Found)
                            {
                                currentList[indexOfItem].Found = true;
                                ShiftToBegin(indexOfItem, currentList);
                                if (currentList.All(x => x.Found))
                                {
                                    indexes.Add(i - totalLength + 1);
                                    currentList.Last().Found = false;
                                }
                            }
                            else
                            {
                                for (var j = indexOfItem + 1; j < currentList.Count; j++)
                                {
                                    if (!currentList[j].Found)
                                    {
                                        break;
                                    }

                                    currentList[j].Found = false;
                                }

                                ShiftToBegin(indexOfItem, currentList);
                            }
                        }
                        else
                        {
                            currentList.ForEach(x => x.Found = false);
                        }

                        buffer.Remove(0, 1);
                    }
                }

                return indexes;
            }

            private void ShiftToBegin(int index, List<DataItem> list)
            {
                while (index > 0)
                {
                    var temp = list[index];
                    list[index] = list[index - 1];
                    list[index - 1] = temp;
                    index--;
                }
            }

            private class DataItem
            {
                public string Word { get; set; }

                public bool Found { get; set; }
            }
        }
    }
}
