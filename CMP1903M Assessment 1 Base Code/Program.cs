using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    class Program
    {
        static void Main()

        {
            // Create 'Input', 'Analyse' and 'Report' object.
            Input inputClass = new Input();
            Analyse analyseClass = new Analyse();
            Report reportClass = new Report();

            // Prompt user for either text from a .txt file, or from text entered in the console.
            string textToBeAnalysed = " ";
            string option = inputClass.UserOptions();
            if (option == "1")
            {
                // Check whether the user has entered valid text, if so reassign variable to the inputted text.
                textToBeAnalysed = inputClass.ManualTextInput();
            }
            else if (option == "2")
            {
                // Check whether the user has entered a valid file path, if so reassign the variable to the text within
                // the file.
                textToBeAnalysed = inputClass.FilePathInput();
                textToBeAnalysed = inputClass.FileTextInput(textToBeAnalysed);
               
            }
            
            // Create a dictionary of the letters and their frequency from the text.
            Dictionary<char, int> characterDictionary = analyseClass.LetterFrequency(textToBeAnalysed);
            
            // Local list of integers to hold the first five measurements of the text.
            List<int> parameters = new List<int>();
            // Create a list of the values of the vowels, consants etc from the text.
            parameters = analyseClass.AnalyseText(textToBeAnalysed);
            
            // Output the vowels, consonants, uppercase, lowercase and sentences to the console.
            reportClass.OutputToConsole(parameters);
            
            // Output the letters and their frequency in alphabetical order to the console.
            reportClass.LetterFrequencyOutputToConsole(characterDictionary);
            
            // Create and produce a list of words over 7 characters long and output to a .txt file
            // if the user entered option 2.
            if (option == "2")
            {
                List<string> longWordList = analyseClass.WordCount(textToBeAnalysed);
                reportClass.LongWordsToFile(longWordList);
            }
        }
    }
}
