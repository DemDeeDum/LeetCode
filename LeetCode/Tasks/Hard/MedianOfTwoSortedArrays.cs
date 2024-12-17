using System.Reflection;

namespace LeetCode.Tasks.Hard
{
    internal class MedianOfTwoSortedArrays
    {
        public class Solution
        {
            enum LastTakenValue
            {
                None,
                One,
                Two
            }

            public double FindMedianSortedArrays(int[] nums1, int[] nums2)
            {
                if (nums1.Length == 0)
                {
                    return TakeMedianFromArray(nums2);
                }
                else if (nums2.Length == 0)
                {
                    return TakeMedianFromArray(nums1);
                }
                else if (nums1.Length == 0 && nums2.Length == 0)
                {
                    return 0;
                }

                if (nums2[0] > nums1[nums1.Length - 1])
                {
                    return HandleOneArrayNumbersBigger(nums2, nums1);
                }
                else if (nums1[0] > nums2[nums2.Length - 1])
                {
                    return HandleOneArrayNumbersBigger(nums1, nums2);
                }

                return HandleCaseWithIntersectedArrays(nums1, nums2);
            }

            private double TakeMedianFromArray(int[] array)
            {
                if (array.Length % 2 == 0)
                {
                    return (array[array.Length / 2] + array[array.Length / 2 - 1]) / 2d;
                }

                return array[array.Length / 2];
            }

            private double HandleOneArrayNumbersBigger(int[] biggerNumbersArray, int[] smallerNumberArray)
            {
                var offset = smallerNumberArray.Length;
                var totalLength = biggerNumbersArray.Length + smallerNumberArray.Length;
                var index = totalLength / 2;
                var value = index >= offset
                    ? biggerNumbersArray[index - offset]
                    : smallerNumberArray[index];

                if (totalLength % 2 == 0)
                {
                    var indexTwo = totalLength / 2 - 1;
                    var valueTwo = indexTwo >= offset
                        ? biggerNumbersArray[indexTwo - offset]
                        : smallerNumberArray[indexTwo];

                    return (value + valueTwo) / 2d;
                }

                return value;
            }

            private double HandleCaseWithIntersectedArrays(int[] numsOne, int[] numsTwo)
            {
                var totalLength = numsOne.Length + numsTwo.Length;
                var shouldTakeOne = totalLength % 2 == 1;
                var indexOne = 0;
                var indexTwo = 0;
                var lastTakeValue = LastTakenValue.None;
                var potentialValueOne = numsOne[indexOne++];
                var potentialValueTwo = numsTwo[indexTwo++];
                var previousValueOne = int.MinValue;
                var previousValueTwo = int.MinValue;
                var valueOne = int.MinValue;
                var valueTwo = int.MinValue;
                var globalIndex = 0;
                var edgeForLoop = shouldTakeOne
                    ? totalLength / 2 + 1
                    : totalLength / 2 + 1;

                while (globalIndex < edgeForLoop)
                {
                    if ((potentialValueOne > potentialValueTwo || potentialValueOne == int.MinValue) && potentialValueTwo != int.MinValue)
                    {
                        lastTakeValue = LastTakenValue.Two;
                        previousValueTwo = valueTwo;
                        valueTwo = potentialValueTwo;
                        if (indexTwo < numsTwo.Length)
                        {
                            potentialValueTwo = numsTwo[indexTwo++];
                        }
                        else
                        {
                            potentialValueTwo = int.MinValue;
                        }
                    }
                    else if ((potentialValueTwo > potentialValueOne || potentialValueTwo == int.MinValue) && potentialValueOne != int.MinValue)
                    {
                        lastTakeValue = LastTakenValue.One;
                        previousValueOne = valueOne;
                        valueOne = potentialValueOne;
                        if (indexOne < numsOne.Length)
                        {
                            potentialValueOne = numsOne[indexOne++];
                        }
                        else
                        {
                            potentialValueOne = int.MinValue;
                        }
                    }
                    else if (potentialValueOne == potentialValueTwo)
                    {
                        if (lastTakeValue == LastTakenValue.Two || lastTakeValue == LastTakenValue.None || potentialValueTwo == int.MinValue)
                        {
                            lastTakeValue = LastTakenValue.One;
                            valueOne = potentialValueOne;
                            if (indexOne < numsOne.Length)
                            {
                                potentialValueOne = numsOne[indexOne++];
                            }
                            else
                            {
                                potentialValueOne = int.MinValue;
                            }
                        }
                        else if (lastTakeValue == LastTakenValue.One || potentialValueOne == int.MinValue)
                        {
                            lastTakeValue = LastTakenValue.Two;
                            valueTwo = potentialValueTwo;
                            if (indexTwo < numsTwo.Length)
                            {
                                potentialValueTwo = numsTwo[indexTwo++];
                            }
                            else
                            {
                                potentialValueTwo = int.MinValue;
                            }
                        }
                        else if (globalIndex == edgeForLoop - 1) // last iteration
                        {
                            if (lastTakeValue == LastTakenValue.Two || lastTakeValue == LastTakenValue.None)
                            {
                                valueOne = potentialValueOne;
                            }
                            else
                            {
                                valueTwo = potentialValueTwo;
                            }
                        }
                        else
                        {
                            // Not expected
                        }
                    }

                    globalIndex++;
                }

                if (!shouldTakeOne && totalLength > 2)
                {
                    var firstOperand = Math.Max(valueOne, valueTwo);
                    var secondOperand = Math.Max(previousValueOne, Math.Max(previousValueTwo, Math.Min(valueOne, valueTwo)));

                    return (firstOperand + secondOperand) / 2d;
                }
                else
                {
                    return Math.Max(valueOne, valueTwo);
                }
            }
        }
    }
}
