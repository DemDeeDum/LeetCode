namespace LeetCode.Tasks.Easy
{
    internal class RansomNote
    {
        public class Solution
        {
            public bool CanConstruct(string ransomNote, string magazine)
            {
                var listBannedIndexes = new List<int>();
                for (var i = 0; i < ransomNote.Length; i++)
                {
                    var index = 0;
                    var startIndex = 0;
                    do
                    {
                        if (startIndex >= magazine.Length)
                        {
                            return false;
                        }

                        index = magazine.IndexOf(ransomNote[i], startIndex);
                        if (index == -1)
                        {
                            return false;
                        }

                        startIndex = index + 1;
                    }
                    while (listBannedIndexes.Contains(index));

                    listBannedIndexes.Add(index);
                }

                return true;
            }
        }
    }
}
