namespace CMP1903M_Assessment_1_Base_Code;

public class InvalidSentenceException : Exception
{
    // Handles custom exceptions for invalid sentence input and displays the appropriate message to the user.
    public InvalidSentenceException(string message) : base(message) {}
}