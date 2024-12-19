using System.Text;

namespace LeetCode.Tasks.Hard
{
    internal class IntegerToEnglishWords
    {
        public class Solution
        {
            const string Zero = "Zero";
            const string One = "One";
            const string Two = "Two";
            const string Three = "Three";
            const string Four = "Four";
            const string Five = "Five";
            const string Six = "Six";
            const string Seven = "Seven";
            const string Eight = "Eight";
            const string Nine = "Nine";
            const string Ten = "Ten";
            const string Eleven = "Eleven";
            const string Twelve = "Twelve";
            const string Thirteen = "Thirteen";
            const string Fourteen = "Fourteen";
            const string Fifteen = "Fifteen";
            const string Sixteen = "Sixteen";
            const string Seventeen = "Seventeen";
            const string Eigthteen = "Eighteen";
            const string Nineteen = "Nineteen";
            const string Twenty = "Twenty";
            const string Thirty = "Thirty";
            const string Forty = "Forty";
            const string Fifty = "Fifty";
            const string Sixty = "Sixty";
            const string Seventy = "Seventy";
            const string Eighty = "Eighty";
            const string Ninety = "Ninety";
            const string Hundred = "Hundred";
            const string Thousand = "Thousand";
            const string Million = "Million";
            const string Billion = "Billion";
            const string Trillion = "Trillion";
            const char Separator = ' ';

            public string NumberToWords(decimal num)
            {
                if (num == 0)
                {
                    return Zero;
                }

                var numberBuilder = new StringBuilder();
                var somethingWasSet = false;
                var appendSeparatorIfNotEmpty = somethingWasSet;

                GetThreeNumbers(num / 1000000000000, Trillion, numberBuilder, ref appendSeparatorIfNotEmpty);
                GetThreeNumbers(num / 1000000000, Billion, numberBuilder, ref appendSeparatorIfNotEmpty);
                GetThreeNumbers(num / 1000000, Million, numberBuilder, ref appendSeparatorIfNotEmpty);
                GetThreeNumbers(num / 1000, Thousand, numberBuilder, ref appendSeparatorIfNotEmpty);
                GetThreeNumbers(num, string.Empty, numberBuilder, ref appendSeparatorIfNotEmpty);

                return numberBuilder.ToString();
            }

            private void GetThreeNumbers(decimal num, string label, StringBuilder builder, ref bool appendSeparatorIfNotEmpty)
            {
                bool somethingWasSet;
                GetHundred(num, out somethingWasSet, builder, ref appendSeparatorIfNotEmpty);
                appendSeparatorIfNotEmpty = somethingWasSet | appendSeparatorIfNotEmpty;

                GetTensNumbers(num, ref somethingWasSet, builder, ref appendSeparatorIfNotEmpty);
                appendSeparatorIfNotEmpty = somethingWasSet | appendSeparatorIfNotEmpty;

                if (somethingWasSet && label != string.Empty)
                {
                    builder.Append(Separator);
                    builder.Append(label);
                }
            }

            private void GetHundred(decimal num, out bool somethingWasSet, StringBuilder builder, ref bool appendSeparatorIfNotEmpty)
            {
                var thirdNumber = num / 100 % 10;
                var hundred = GetNumberForDigit(thirdNumber);
                if (hundred == string.Empty)
                {
                    somethingWasSet = false;

                    return;
                }

                if (appendSeparatorIfNotEmpty)
                {
                    builder.Append(Separator);
                }

                somethingWasSet = true;
                builder.Append(hundred);
                builder.Append(Separator);
                builder.Append(Hundred);
            }

            private void GetTensNumbers(decimal num, ref bool somethingWasSet, StringBuilder builder, ref bool appendSeparatorIfNotEmpty)
            {
                var firstTwo = num % 100;
                if (firstTwo < 1)
                {
                    return;
                }

                if (appendSeparatorIfNotEmpty)
                {
                    builder.Append(Separator);
                    appendSeparatorIfNotEmpty = false;
                }

                somethingWasSet = true;
                var secondNumber = string.Empty;
                var firstNumber = string.Empty;
                if (firstTwo >= 20)
                {
                    secondNumber = ((int)firstTwo / 10) switch
                    {
                        2 => Twenty,
                        3 => Thirty,
                        4 => Forty,
                        5 => Fifty,
                        6 => Sixty,
                        7 => Seventy,
                        8 => Eighty,
                        9 => Ninety
                    };

                    firstNumber = GetNumberForDigit(firstTwo % 10);
                }
                else if (firstTwo >= 10)
                {
                    secondNumber = (int)firstTwo switch
                    {
                        10 => Ten,
                        11 => Eleven,
                        12 => Twelve,
                        13 => Thirteen,
                        14 => Fourteen,
                        15 => Fifteen,
                        16 => Sixteen,
                        17 => Seventeen,
                        18 => Eigthteen,
                        19 => Nineteen
                    };
                }
                else
                {
                    firstNumber = GetNumberForDigit(firstTwo % 10);
                }

                var secondNumberSet = secondNumber != string.Empty;
                if (secondNumberSet)
                {
                    builder.Append(secondNumber);
                }

                if (firstNumber != string.Empty)
                {
                    if (secondNumberSet)
                    {
                        builder.Append(Separator);
                    }

                    builder.Append(firstNumber);
                }  
            }

            private string GetNumberForDigit(decimal digit)
            {
                return (int)digit switch
                {
                    0 => string.Empty,
                    1 => One,
                    2 => Two,
                    3 => Three,
                    4 => Four,
                    5 => Five,
                    6 => Six,
                    7 => Seven,
                    8 => Eight,
                    9 => Nine,
                };
            }
        }
    }
}
