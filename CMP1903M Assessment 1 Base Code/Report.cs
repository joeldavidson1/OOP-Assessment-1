using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    class Report
    {
        // Method: OutputToConsole.
        // Arguments: List of integers.
        // Returns: none.
        // Receives a list and outputs the corresponding values to the console in a readable format.
        public void OutputToConsole(List <int> analysis)
        {
            Console.WriteLine("\nAnalysis of the text:");
            Console.WriteLine($"Number of sentences entered = {analysis[0]}");
            Console.WriteLine($"Number of vowels = {analysis[1]}");
            Console.WriteLine($"Number of consonants = {analysis[2]}");
            Console.WriteLine($"Number of upper case letters = {analysis[3]}");
            Console.WriteLine($"Number of lower case letters = {analysis[4]}");
        }

        // Method: LetterFrequencyOutputToConsole.
        // Arguments: Dictionary of the letters and their frequency (integers).
        // Returns: none.
        // Receives a dictionary and outputs the corresponding values to the console in a readable format.
        public void LetterFrequencyOutputToConsole(Dictionary<char, int> charFrequency)
        {
            foreach (var charAndFrequency in charFrequency)
            {
                // Checks the keys to see if they are upper and lower case letters only.
                if ((charAndFrequency.Key >= 'a' && charAndFrequency.Key <= 'z') ||
                    (charAndFrequency.Key >= 'A' && charAndFrequency.Key <= 'Z'))
                {
                    Console.WriteLine($"Letter: {charAndFrequency.Key} Frequency: {charAndFrequency.Value}");
                }

            }
        }
        
        // Method: LongWordsToFile.
        // Arguments: List of strings (long words).
        // Returns: none.
        // Outputs the list of long words to a .txt file in the applications current directory.
        public void LongWordsToFile(List<string> words)
        {
            // Get the current directory of the user's application and writes to a longwords.txt file.
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "longwords.txt");
            File.WriteAllLines(path, words);
            
            Console.WriteLine("Check the application's directory for the 'longwords.txt' file for a" +
                              " list of words over 7 characters.");
        }
    }
}
