namespace LeetCode.Tasks.Easy
{
    internal class PascalTriangleTwo
    {
        public class Solution
        {
            public IList<int> GetRow(int rowIndex)
            {
                var list = new List<int> (rowIndex) { 1 };
                for (var i = 1; i < rowIndex; i++)
                {
                    list.Add(1);
                    for (var j = list.Count - 2; j > 0; j--)
                    {
                        list[j] += list[j - 1];
                    }
                }

                return list;
            }
        }
    }
}
