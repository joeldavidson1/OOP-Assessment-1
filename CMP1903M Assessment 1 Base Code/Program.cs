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
            // Local list of integers to hold the first five measurements of the text.
            List<int> parameters = new List<int>();

            // Create 'Input', 'Analyse' and 'Report' object.
            Input inputClass = new Input();
            Analyse analyseClass = new Analyse();
            Report reportClass = new Report();

            // Prompt user for either text from a .txt file, or from text entered in the console.
            bool continueLoop = true;
            while (continueLoop)
            {
                Console.WriteLine("1. Do you want to enter the text via the keyboard?\n2. " +
                                  "Do you want to read in the text from a .txt file?\nEnter 1 or 2."); 
                string option = Console.ReadLine();
                
                if (option == "1")
                {
                    // Pass the user entered text into the analyseClass for analysis.
                    string userInput = inputClass.ManualTextInput();
                    parameters = analyseClass.AnalyseText(userInput);
                    
                    // Pass the user entered text to the reportClass for a full report on the analysis.
                    reportClass.OutputToConsole(parameters);
                    var characterDictionary = analyseClass.LetterFrequency(userInput);
                    reportClass.LetterFrequencyOutputToConsole(characterDictionary);

                    continueLoop = false;
                }
                else if (option == "2")
                {
                    // Ask the user for a file path of a .txt file and catch invalid file path exceptions.
                    // Checks to see if the file path is valid. If it's not then it prompts the user again.
                    if (inputClass.ValidFileInput() == false)
                    {
                        inputClass.ValidFileInput();
                    }
                    
                    // Obtain the string the user entered after it's passed validation.
                    string filePath = inputClass.text;
                           
                    // Pass the valid .txt file into the analyse and report Classes.
                    string userFile = inputClass.FileTextInput(filePath);
                    parameters = analyseClass.AnalyseText(userFile);
                    reportClass.OutputToConsole(parameters);
                    var characterDictionary = analyseClass.LetterFrequency(userFile);
                    reportClass.LetterFrequencyOutputToConsole(characterDictionary);

                    // Output the list of long words to a .txt file.
                    List<string> longWordList = analyseClass.WordCount(userFile);
                    reportClass.LongWordsToFile(longWordList);
                    
                    continueLoop = false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter either 1 or 2.\n");
                }
            }
        }     
    }
}
