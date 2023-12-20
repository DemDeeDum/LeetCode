namespace LeetCode.Tasks.Hard
{
    internal class Candy
    {
        public class Solution
        {
            public int Candy(int[] ratings)
            {
                var lastMax = 0;
                var lastMaxIndex = 0;
                var prevExtraCandy = 0;
                var total = ratings.Length;
                for (var i = 0; i < ratings.Length; i++)
                {
                    var currentExtraCandy = 0;
                    if (i > 0 && ratings[i] > ratings[i - 1])
                    {
                        currentExtraCandy += prevExtraCandy + 1;
                        var j = i;
                        while (j > 0 && ratings[j] < ratings[j - 1])
                        {
                            total++;
                            j--;
                        }

                        lastMax = currentExtraCandy;
                        lastMaxIndex = i;
                    }
                    
                    if (i < ratings.Length - 1 && ratings[i] > ratings[i + 1] && currentExtraCandy == 0)
                    {
                        currentExtraCandy += 1;
                        var j = i;
                        while(j > 0 && ratings[j] < ratings[j - 1] && currentExtraCandy >= prevExtraCandy)
                        {
                            if (j - 1 == lastMaxIndex)
                            {
                                if (i - j + currentExtraCandy < lastMax)
                                {
                                    break;
                                }
                                else
                                {
                                    lastMax++;
                                }
                            }

                            total++;
                            j--;
                        }
                    }

                    total += currentExtraCandy;
                    prevExtraCandy = currentExtraCandy;
                }

                return total;
            }
        }
    }
}
