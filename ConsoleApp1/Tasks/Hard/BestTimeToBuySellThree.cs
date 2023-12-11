namespace LeetCode.Tasks.Hard
{
    public class BestTimeToBuySellThree
    {
        public class Solution
        {
            public int MaxProfit(int[] prices)
            {
                #region Try Without Comments/Learnings FAILED
                //(int Begin, int End) maxSum1Range = (-1, -1);
                //var maxSum1 = 0;
                //(int Begin, int End) maxSum2Range = (-1, -1);
                //var maxSum2 = 0;
                //var sum2Used = false;

                //for (var i = 0; i < prices.Length; i++)
                //{
                //    for (var j = prices.Length - 1; j > i; j--)
                //    {
                //        var possibleSum = prices[j] - prices[i];
                //        if (maxSum1 < possibleSum)
                //        {
                //            if (maxSum1 == 0)
                //            {
                //                maxSum1 = possibleSum;
                //                maxSum1Range = (i, j);
                //            }
                //            else if (i >= maxSum1Range.Begin && i <= maxSum1Range.End
                //                || j >= maxSum1Range.Begin && j <= maxSum1Range.End)
                //            {
                //                if (i >= maxSum2Range.Begin && i <= maxSum2Range.End
                //                || j >= maxSum2Range.Begin && j <= maxSum2Range.End)
                //                {
                //                    if (maxSum1 + maxSum2 > possibleSum)
                //                    {
                //                        sum2Used = true;
                //                        continue;
                //                    }
                //                    else
                //                    {
                //                        sum2Used = false;
                //                    }
                //                }

                //                maxSum1 = possibleSum;
                //                maxSum1Range = (i, j);
                //            }
                //            else
                //            {
                //                maxSum2 = maxSum1;
                //                maxSum2Range = maxSum1Range;
                //                maxSum1 = possibleSum;
                //                maxSum1Range = (i, j);
                //                sum2Used = true;
                //            }
                //        }
                //        else if (maxSum2 < possibleSum
                //            && !(i >= maxSum1Range.Begin && i <= maxSum1Range.End
                //                || j >= maxSum1Range.Begin && j <= maxSum1Range.End)
                //            && !(i >= maxSum2Range.Begin && i <= maxSum2Range.End
                //                || j >= maxSum2Range.Begin && j <= maxSum2Range.End))
                //        {
                //            maxSum2 = possibleSum;
                //            maxSum2Range = (i, j);
                //            sum2Used = true;
                //        }
                //        else if (!sum2Used && maxSum2 + possibleSum > maxSum1
                //            && !(i >= maxSum2Range.Begin && i <= maxSum2Range.End
                //                || j >= maxSum2Range.Begin && j <= maxSum2Range.End))
                //        {
                //            if (maxSum2 > possibleSum)
                //            {
                //                maxSum1 = maxSum2;
                //                maxSum1Range = maxSum2Range;
                //                maxSum2 = possibleSum;
                //                maxSum2Range = (i, j);
                //            }
                //            else
                //            {
                //                maxSum1 = possibleSum;
                //                maxSum1Range = (i, j);
                //            }

                //            sum2Used = true;
                //        }
                //    }
                //}

                //return maxSum1 + maxSum2;
                #endregion

                var watch = System.Diagnostics.Stopwatch.StartNew();
                var matrixLength = prices.Length - 1;
                var matrix = new int[matrixLength][];
                for(var i = 0; i < matrixLength; i++)
                {
                    matrix[i] = new int[matrixLength - i];
                }
                for (int i = 0; i < prices.Length; i++)
                {
                    for (int j = i + 1, matrixIndex = 0; j < prices.Length; matrixIndex++, j++)
                    {
                        matrix[i][matrixIndex] = prices[j] - prices[i];
                    }
                }

                watch.Stop();
                Console.WriteLine(watch.ElapsedMilliseconds);


                //for (var i = 0; i < matrixLength; i++)
                //{
                //    for (var j = 0; j < matrix[i].Length; j++)
                //    {
                //        Console.Write($"{{{i}; {i + j + 1}}} = {matrix[i][j]}\t");
                //    }
                //    Console.WriteLine();
                //}

                watch.Restart();

                var max = 0;
                for (var i = 0; i < matrixLength; i++)
                {
                    Console.WriteLine(watch.ElapsedMilliseconds); 
                    for (var j = 0; j < matrix[i].Length; j++)
                    {
                        if (matrix[i][j] <= 0)
                        {
                            continue;
                        }

                        var tempMax = 0;
                        for (var k = i + j + 2; k < matrixLength; k++)
                        {
                            for (var s = 0; s < matrix[k].Length; s++)
                            {
                                if (tempMax < matrix[k][s])
                                {
                                    tempMax = matrix[k][s];
                                }
                            }
                        }

                        tempMax += matrix[i][j];
                        if (tempMax > max)
                        {
                            max = tempMax;
                        }
                    }
                }

                return max;
            }
        }
    }
}
