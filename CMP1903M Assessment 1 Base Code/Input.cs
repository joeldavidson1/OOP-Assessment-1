using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class Input
    {
        // Handles the text input for Assessment 1.
        // Encapsulate the text variable so it can only be set inside the Input class, but can be accessed elsewhere.
        public string text { get; private set; }

        // Method: manualTextInput.
        // Arguments: none.
        // Returns: string.
        // Gets text input from the keyboard.
        public string ManualTextInput()
        {
            try
            {
                Console.WriteLine("Please end the sentences with proper punctuation." +
                                  " Enter the text to be analysed: ");
                text = Console.ReadLine();

                // Checks to see if the string is empty or just whitespace.
                if (string.IsNullOrWhiteSpace(text))
                {
                    throw new InvalidSentenceException("The text must contain letters to be analysed.\n");
                }
                
                // Checks to see if the string contains only numbers.
                if (text.All(Char.IsDigit))
                {
                    throw new InvalidSentenceException("The text must contain more than " + "integers to be analysed.\n");
                }
                
                // Checks to see if the string contains valid end of sentence punctuation.
                if (!(text.Contains('.') || text.Contains('?') || text.Contains('!')))
                {
                    throw new InvalidSentenceException("Sentences must end with the correct punctuation to" +
                                                       " be analysed: '.', '!', '?'\n");
                }
                
                // Checks to see if the string contains only punctuation.
                if (text.All(Char.IsPunctuation))
                {
                    throw new InvalidSentenceException("The text must contain letters to be analysed.\n");
                }
            }
            
            // Catches the exception and displays the corresponding message.
            catch (InvalidSentenceException e)
            {
                Console.WriteLine(e.Message);
                ManualTextInput();
            }
            return text;
        }

        // Method: FileTextInput.
        // Arguments: string (the file path).
        // Returns: string.
        // Gets text input from a .txt file.
        public string FileTextInput(string fileName)
        {
            text = File.ReadAllText(fileName);
            return text;
        }

        // Method: ValidFileInput.
        // Arguments: none.
        // Returns: bool.
        // Gets a string from the user and catches various exceptions to see if it is a valid file path. Returns true
        // only when the path is valid.
        public bool ValidFileInput()
        {
            bool valid = true;
            try
            {
                Console.WriteLine("Please enter a valid file path for a .txt file: ");
                text = Console.ReadLine();
                File.ReadAllText(text);
            }

            // Checks whether the file can be found.
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file cannot be found.\n");
                valid = false;
            }

            // Checks whether the directory can be found.
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The directory cannot be found.\n");
                valid = false;
            }

            // Checks see if a string entered so the method parameter is fulfilled.
            catch (ArgumentException)
            {
                Console.WriteLine("Cannot find a file with an empty string path.\n");
                valid = false;
            }

            // Checks to see if the user has access to the file or directory.
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Do not have access to this directory or file.\n");
                valid = false;
            }

            // Checks to see if the user has entered an empty string.
            catch (NullReferenceException)
            {
                Console.WriteLine("Cannot find a file with an empty string path.\n");
                valid = false;
            }

            return valid;
        }
    }
}
