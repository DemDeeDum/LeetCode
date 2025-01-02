namespace LeetCode.Tasks.Easy
{
    internal class PascalTriangle
    {
        public class Solution
        {
            public IList<IList<int>> Generate(int numRows)
            {
                var mainList = new List<IList<int>>(numRows);
                for (var i = 1; i <= numRows; i++)
                {
                    var newList = new List<int>(i) { 1 };
                    if (i > 1)
                    {
                        newList.Add(1);
                    }

                    if (i > 2)
                    {
                        for (var j = 1; j < i - 1; j++)
                        {
                            newList.Insert(j, mainList[i - 2][j - 1] + mainList[i - 2][j]);
                        }
                    }

                    mainList.Add(newList);
                }

                return mainList;
            }
        }
    }
}
