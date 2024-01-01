namespace LeetCode.Tasks.Hard
{
    internal class TrappingRainWater
    {
        public class Solution
        {
            public int Trap(int[] height)
            {
                var totalWater = 0;
                var index = 0;
                var valueIndex = -1;
                var trunksSpace = 0;
                var temporary = 0;

                do
                {
                    if (height[index] > 0)
                    {
                        if (valueIndex == -1)
                        {
                            valueIndex = index;
                            temporary = height[valueIndex] * (height.Length - index - 1);
                        }
                        else if (height[index] < height[valueIndex])
                        {


                            trunksSpace += height[index];
                        }
                        else if (height[index] >= height[valueIndex])
                        {
                            totalWater += height[valueIndex] * (index - valueIndex - 1) - trunksSpace;
                            valueIndex = index;
                            //temporary = height[valueIndex] * (height.Length - index - 1);
                        }
                    }
                    else
                    {
                        temporary += height[valueIndex];
                    }
                }
                while (++index < height.Length);

                return totalWater;
            }
        }
    }
}
