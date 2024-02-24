namespace LeetCode.Tasks.Medium
{
    internal class GroupAnagrams
    {
        public class Solution
        {
            public IList<IList<string>> GroupAnagrams(string[] strs)
            {
                var listOflists = new List<IList<string>>();

                foreach (var str in strs)
                {
                    var found = false;
                    foreach (var list in listOflists)
                    {
                        if (IsAnagram(list.First(), str))
                        {
                            list.Add(str);
                            found = true;

                            break;
                        }
                    }

                    if (!found)
                    {
                        listOflists.Add(new List<string> { str });
                    }
                }

                return listOflists;
            }

            private bool IsAnagram(string s, string t)
            {
                if (s.Length != t.Length)
                {
                    return false;
                }

                var dictionaryS = new Dictionary<char, int>();
                var dictionaryT = new Dictionary<char, int>();
                for (int i = 0; i < s.Length; i++)
                {
                    if (dictionaryS.ContainsKey(s[i]))
                    {
                        dictionaryS[s[i]]++;
                    }
                    else
                    {
                        dictionaryS.Add(s[i], 1);
                    }

                    if (dictionaryT.ContainsKey(t[i]))
                    {
                        dictionaryT[t[i]]++;
                    }
                    else
                    {
                        dictionaryT.Add(t[i], 1);
                    }
                }

                return dictionaryS.All(x => dictionaryT.TryGetValue(x.Key, out var count) ? count == x.Value : false) && dictionaryT.All(x => dictionaryS.ContainsKey(x.Key));
            }
        }
    }
}
