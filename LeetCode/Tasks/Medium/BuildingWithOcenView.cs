namespace LeetCode.Tasks.Medium
{
    internal class BuildingWithOcenView
    {
        public class Solution
        {
            public int[] FindBuildings(int[] heights)
            {
                var sortedListOfHeights = new SortedList<int, int>(heights.Length);
                for (var i = 0; i < heights.Length; i++)
                {
                    sortedListOfHeights[heights[i]] = i;
                    var indexOfNewlyAdded = sortedListOfHeights.IndexOfKey(heights[i]);
                    while (indexOfNewlyAdded != 0)
                    {
                        sortedListOfHeights.RemoveAt(0);
                        indexOfNewlyAdded = sortedListOfHeights.IndexOfKey(heights[i]);
                    }
                }

                return sortedListOfHeights.Values.Reverse().ToArray();
            }
        }
    }
}
