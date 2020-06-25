using System;
using System.Collections.Generic;
using System.Text;

namespace NumToWords
{
    public class NumberConversion
    {
        public long WordsToNum(String spelledNumber)
        {
            if (String.IsNullOrEmpty(spelledNumber))
            {
                return -1;
            }

            Dictionary<String, int> numberCollection = new Dictionary<String, int>()
                {
                    { "Billion", 1000000000},
                    { "Million", 1000000},
                    { "Thousand", 1000},
                    { "Hundred", 100},
                    { "Ninety", 90},
                    { "Eighty", 80},
                    { "Seventy", 70},
                    { "Sixty", 60},
                    { "Fifty", 50},
                    { "Forty", 40},
                    { "Thirty", 30},
                    { "Twenty", 20},
                    { "Nineteen", 19},
                    { "Eighteen", 18},
                    { "Seventeen", 17},
                    { "Sixteen", 16},
                    { "Fifteen", 15},
                    { "Fourteen", 14},
                    { "Thirteen", 13},
                    { "Twelve", 12},
                    { "Eleven",  11},
                    { "Ten", 10},
                    { "Nine",9},
                    { "Eight", 8},
                    { "Seven", 7},
                    { "Six", 6},
                    { "Five", 5},
                    { "Four", 4},
                    { "Three", 3},
                    { "Two", 2},
                    { "One", 1}
                };

            string[] words = spelledNumber.Split(' ');
            long result = 0; long currentNumber = 0; 

            foreach (String word in words)
            {
                if (!word.Equals("and", StringComparison.OrdinalIgnoreCase) && !numberCollection.ContainsKey(word))
                {
                    throw new ArgumentException("The given word does not match any correct number.");
                }
                if (word.Equals("and", StringComparison.OrdinalIgnoreCase)) {
                    continue;
                }

                if (numberCollection[word] < 100 ) { 
                    currentNumber += numberCollection[word];
                }

                if (String.Equals(word, "Hundred", StringComparison.OrdinalIgnoreCase)) {
                    currentNumber *= numberCollection[word];
                }

                if (String.Equals(word, "Thousand", StringComparison.OrdinalIgnoreCase) || String.Equals(word, "Million", StringComparison.OrdinalIgnoreCase) || String.Equals(word, "Billion", StringComparison.OrdinalIgnoreCase)) {
                    // Stop calculating the current number and add to the total and reset currentNumber to 0
                    currentNumber *= numberCollection[word];
                    result+= currentNumber;
                    currentNumber = 0;                    
                }
            }
            result += currentNumber;
            return result;
        }

        public String NumToWords(int number)
        {
            if (number < 0)
            {
                return String.Empty;
            }

            Dictionary<int, String> numberCollection = new Dictionary<int, string>()
                {
                    {1000000000, "Billion"},
                    {1000000, "Million"},
                    {1000, "Thousand"},
                    {100, "Hundred"},
                    {90,"Ninety"},
                    {80, "Eighty"},
                    {70, "Seventy"},
                    {60, "Sixty"},
                    {50, "Fifty"},
                    {40, "Forty"},
                    {30, "Thirty"},
                    {20, "Twenty"},
                    {19, "Nineteen"},
                    {18, "Eighteen"},
                    {17, "Seventeen"},
                    {16, "Sixteen"},
                    {15, "Fifteen"},
                    {14, "Fourteen"},
                    {13, "Thirteen"},
                    {12, "Twelve"},
                    {11, "Eleven"},
                    {10, "Ten"},
                    {9, "Nine"},
                    {8, "Eight"},
                    {7, "Seven"},
                    {6, "Six"},
                    {5, "Five"},
                    {4, "Four"},
                    {3, "Three"},
                    {2, "Two"},
                    {1, "One"}
                };

            StringBuilder spelledNumber = new StringBuilder();

            foreach (var pair in numberCollection)
            {
                while (pair.Key <= number)
                {
                    int placeNumber = number / pair.Key;
                    if (placeNumber >= 10)
                    {
                        int current = placeNumber;

                        foreach (var currentPair in numberCollection)
                        {
                            while (currentPair.Key <= current)
                            {
                                int currentPlace = current / currentPair.Key;
                                if (current >= 100)
                                {
                                    spelledNumber.Append(numberCollection[currentPlace] + ' ' + currentPair.Value + " and ");
                                }
                                else
                                {
                                    spelledNumber.Append(currentPair.Value + ' ');
                                }
                                current -= (currentPlace * currentPair.Key);
                            }
                        }
                    }
                    else if (number >= 100)
                    {
                        spelledNumber.Append(numberCollection[placeNumber] + ' ');
                    }
                    spelledNumber.Append(pair.Value + ' ');
                    if ((number - (placeNumber * pair.Key)) > 0 && (pair.Key == 100 || pair.Key == 1000))
                    {
                        spelledNumber.Append("and ");
                    }
                    number -= (placeNumber * pair.Key);
                }
            }

            return spelledNumber.ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            NumberConversion _conversionService = new NumberConversion();
            string result = _conversionService.NumToWords(21656704);
            Console.WriteLine(result);
            long no = _conversionService.WordsToNum("Twenty One Million Six Hundred and Fifty Six Thousand and Seven Hundred and Four");
            Console.WriteLine(no);
        }
    }
}
