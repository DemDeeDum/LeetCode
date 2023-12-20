namespace LeetCode.Tasks.Medium
{
    internal class GasStation
    {
        public class Solution
        {
            public int CanCompleteCircuit(int[] gas, int[] cost)
            {
                var length = gas.Length;
                for (var i = 0; i < length; i++)
                {
                    if (i == 0 || gas[i - 1] - cost[i - 1] < gas[i] - cost[i])
                    {
                        var gasAmount = 0;
                        var j = i;
                        while (true)
                        {
                            gasAmount += gas[j] - cost[j];
                            if (gasAmount < 0)
                            {
                                break;
                            }

                            if (++j >= gas.Length)
                            {
                                j = 0;
                            }

                            if (j == i)
                            {
                                return i;
                            }
                        }
                    }
                }

                return -1;
            }
        }
    }
}
