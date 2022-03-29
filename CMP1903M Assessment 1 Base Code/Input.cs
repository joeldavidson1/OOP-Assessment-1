using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class Input
    {
        // Handles the text input for Assessment 1.
        // Encapsulate the text variable so it can only be set inside the Input class.
        private string text { get; set; }

        // Method: manualTextInput.
        // Arguments: none.
        // Returns: string.
        // Gets text input from the keyboard.
        public string ManualTextInput()
        {
            try
            {
                Console.WriteLine("Please end the sentences with proper punctuation and end the text with" +
                                  " an asterisk (*)." + " Enter the text to be analysed: ");
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

                if (!text.Contains('*'))
                {
                    throw new InvalidSentenceException("Text must include an * to be analysed.\n");
                }
            }
            
            // Catches the exception and displays the corresponding message.
            catch (InvalidSentenceException e)
            {
                Console.WriteLine(e.Message);
                ManualTextInput();
            }
            
            // Only returns the text before the *.
            TextBeforeCharacter(text);
            return text;
        }
        
        // Method: TextBeforeCharacter
        // Arguments: string
        // Returns: All of a string before a *.
        // Get all the text before an asterisk (*) and returns it as a string. 
        private string TextBeforeCharacter(string words)
        {
            words = words.Split('*')[0];
            return words;
        }
        
        // Method: FileTextInput.
        // Arguments: string (the file path).
        // Returns: string.
        // Gets text input from a .txt file.
        public string FileTextInput(string fileName)
        {
            // Fetches the text from the requested file, and returns the text before a *.
            string fileText = File.ReadAllText(fileName);
            text = TextBeforeCharacter(fileText);
            return text;
        }

        // Method: ValidFileInput.
        // Arguments: none.
        // Returns: bool.
        // Gets a string from the user and catches various exceptions to see if it is a valid file path. Returns true
        // only when the path is valid.
        private bool ValidFileInput(string filePath)
        {
            bool valid = true;
            try
            {
                File.ReadAllText(filePath);
            }

            // Checks whether the file can be found.
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file cannot be found.");
                valid = false;
            }

            // Checks whether the directory can be found.
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The directory cannot be found.");
                valid = false;
            }

            // Checks see if a string entered so the method parameter is fulfilled.
            catch (ArgumentException)
            {
                Console.WriteLine("Cannot find a file with an empty string path.");
                valid = false;
            }

            // Checks to see if the user has access to the file or directory.
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Do not have access to this directory or file.");
                valid = false;
            }

            // Checks to see if the user has entered an empty string.
            catch (NullReferenceException)
            {
                Console.WriteLine("Cannot find a file with an empty string path.");
                valid = false;
            }
            // Catches any other unhandled exceptions that are raised.
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error found: {ex.Message}");
                valid = false;
            }

            return valid;
        }
        
        // COMMENT CORRECTLY
        public string FilePathInput()
        {
            Console.WriteLine("Please enter a valid file path for a .txt file: ");
            string filePath = Console.ReadLine();
            text = filePath;
            
            while (true)
            {
                if (ValidFileInput(filePath) == false)
                {
                    FilePathInput();
                }

                break;
            }

            return text;
        }

        //  COMMENT CORRECTLY
        public string UserOptions()
        {
            Console.WriteLine("1. Do you want to enter the text via the keyboard?\n2. " +
                              "Do you want to read in the text from a .txt file?\nEnter 1 or 2.");
            string option = Console.ReadLine();

            if (option == "1")
            {
                return option;
            }
            else if (option == "2")
            {
                return option;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter either 1 or 2.\n");
                return UserOptions();
            }
        }
    }
}
