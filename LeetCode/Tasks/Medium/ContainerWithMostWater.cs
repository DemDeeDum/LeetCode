namespace LeetCode.Tasks.Medium
{
    internal class ContainerWithMostWater
    {
        public class Solution
        {
            public int MaxArea(int[] height)
            {
                var firstIndex = -1;
                var secondIndex = 0;
                var max = int.MinValue;
                var localMax = int.MinValue;
                var firstIndexMax = height[0];
                while (firstIndex < height.Length - 1)
                {
                    firstIndex++;
                    if (firstIndexMax > height[firstIndex])
                    {
                        continue;
                    }
                    else
                    {
                        firstIndexMax = height[firstIndex];
                    }

                    secondIndex = height.Length - 1;
                    localMax = int.MinValue;
                    while (firstIndex < secondIndex)
                    {
                        if (height[secondIndex] > localMax)
                        {
                            localMax = height[secondIndex];
                            var commonValue = Math.Min(height[secondIndex], height[firstIndex]);
                            var calculated = (secondIndex - firstIndex) * commonValue;
                            if (calculated > max)
                            {
                                max = calculated;
                            }
                        }

                        secondIndex--;
                    }

                }

                return max;
            }
        }
    }
}
