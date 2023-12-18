namespace LeetCode.Tasks.Easy
{
    internal class MajorityElement
    {
        public class Solution
        {
            public int MajorityElement(int[] nums)
            {
                if (nums.Length == 1)
                {
                    return nums[0];
                }

                var halfOfLength = nums.Length / 2;
                for (var i = 0; i < nums.Length; i++)
                {
                    if (nums[i] == int.MinValue)
                    {
                        continue;
                    }

                    var count = 1;
                    for(var j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[j] == nums[i])
                        {
                            count++;
                            if (count > halfOfLength)
                            {
                                return nums[i];
                            }

                            nums[j] = int.MinValue;
                        }
                    }
                }

                return 0;
            }
        }
    }
}
