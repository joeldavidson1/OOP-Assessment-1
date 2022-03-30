using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class Analyse
    {
        // Encapsulate all the class variables only to be used in the Analyse class.
        private int _vowels { get; set; }
        private int _consonants { get; set; } 
        private int _length { get; set; }
        private int _sentences { get; set; }
        private int _upperChars { get; set; }
        private int _lowerChars { get; set; }

        // Method: AnalyseText.
        // Arguments: string.
        // Returns: list of integers.
        // Calculates and returns an analysis of the text.
        public List<int> AnalyseText(string input)
        {
            // List of integers to hold the first five measurements:
            // 1. Number of sentences.
            // 2. Number of vowels.
            // 3. Number of consonants.
            // 4. Number of upper case letters.
            // 5. Number of lower case letters.
            List<int> values = new List<int>();
            
            //Initialise all the values in the list to '0'.
            for (int i = 0; i < 5; i++)
            {
                values.Add(0);
            }

            _length = input.Length;
            
            // Loop through each character in the text.
            for (int i = 0; i < _length; i++)
            {
                // Check the text for vowels and uppercase letters and increment.
                if (input[i] == 'a' || input[i] == 'e' || input[i] == 'i' || input[i] == 'o' || input[i] == 'u')
                {
                    _vowels++;
                    _lowerChars++;
                }
                
                // Check the text for vowels and uppercase letters and increment.
                else if (input[i] == 'A' || input[i] == 'E' || input[i] == 'I' || input[i] == 'O' || input[i] == 'U')
                {
                    _vowels++;
                    _upperChars++;
                }
                
                // Check the text for consonants and lowercase letters and increment.
                else if (input[i] >= 'a' && input[i] <= 'z')
                {
                    _lowerChars++;
                    _consonants++;
                }
                
                // Check the text for consonants and uppercase letters and increment.
                else if (input[i] >= 'A' && input[i] <= 'Z')
                {
                    _upperChars++;
                    _consonants++;
                }
                
                // Check the text for where a sentence ends and increment.
                else if (input[i] == '.' || input[i] == '!' || input[i] == '?')
                {
                    _sentences++;
                }
            }
            
            // Append the results to the values list.
            values[0] = _sentences;
            values[1] = _vowels;
            values[2] = _consonants;
            values[3] = _upperChars;
            values[4] = _lowerChars;
            
            return values;
        }
        
        
        // Method: LetterFrequency.
        // Arguments: string.
        // Returns: Dictionary of characters and integers.
        // Calculates what letters appear in the text as keys and appends their corresponding frequency to the value.
        public Dictionary<char, int> LetterFrequency(string input)
        {
            // Convert string to lower as to only count letter occurrences not upper and lowercase.
            input = input.ToLower();
            var charFrequency = new Dictionary<char, int>();
            foreach (var c in input)
            {
                // Add letter and its frequency to the dictionary.
                if (charFrequency.ContainsKey(c))
                {
                    charFrequency[c]++;
                }
                else
                {
                    charFrequency[c] = 1;
                }
            }
            return charFrequency;
        }
        
        // Method: WordCount
        // Arguments: string
        // Returns: List of strings (long words).
        // Calculates all words that are over 7 letters long in the text and appends them into the longWords list.
        public List<string> WordCount(string input)
        {
            // Using regular expression to remove any special characters and split the text into just words.
            input = Regex.Replace(input, "[^a-zA-Z0-9]", " ");
            string[] words = input.Split();
            
            // Create a list of words over 7 characters long.
            List<string> longWords = words.Where(s => s.Length > 7).ToList();

            return longWords;
        }
        
        // Method: ValidValues.
        // Arguments: List of integers.
        // Returns: bool
        // Checks to see if the test file meets the expected values in the analysed text list.
        public bool ValidValues(List<int> analysis)
        {
            if (analysis[0] == 6 && analysis[1] == 189 && analysis[2] == 317 && analysis[3] == 9 && analysis[4] == 497)
            {
                return true;
            }
            
            return false;
        }
    }
}
