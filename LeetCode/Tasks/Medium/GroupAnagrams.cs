namespace LeetCode.Tasks.Medium
{
    internal class GroupAnagrams
    {
        public class Solution
        {
            private IDictionary<int, int[]> cache = new Dictionary<int, int[]>();

            public IList<IList<string>> GroupAnagrams(string[] strs)
            {
                var listOflists = new List<IList<string>>();

                for (var j = 0; j < strs.Length; j++)
                {
                    var found = false;
                    for (var i = 0; i < listOflists.Count; i++)
                    {
                        if (listOflists[i].First().Length == strs[j].Length && IsAnagram(i, strs[j]))
                        {
                            listOflists[i].Add(strs[j]);
                            found = true;

                            break;
                        }
                    }

                    if (!found)
                    {
                        listOflists.Add(new List<string> { strs[j] });
                        if (!cache.TryGetValue(-1, out var data))
                        {
                            data = RetrieveData(strs[j]);
                        }
                        else
                        {
                            cache.Remove(-1);
                        }

                        cache.Add(listOflists.Count - 1, data);
                    }
                }

                return listOflists;
            }

            private bool IsAnagram(int index, string s)
            {
                var data = RetrieveData(s);
                var cacheData = cache[index];

                cache[-1] = data;

                for (var i = 0; i < data.Length; i++)
                {
                    if (cacheData[i] != data[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            private int[] RetrieveData(string s)
            {
                var dictionary = new int[26];
                for (int i = 0; i < s.Length; i++)
                {
                    dictionary[s[i] - 97]++;
                }

                return dictionary;
            }
        }
    }
}
