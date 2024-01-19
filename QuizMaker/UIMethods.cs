namespace QuizMaker;

public class UIMethods
{
    public static void PrintWelcomeMessage()
    {
        Console.WriteLine(" Welcome to the Quiz Maker");
        Console.WriteLine("****************************");
        Console.WriteLine();
    }
    
    public static char PlayOrQuestionSelect(char playOption, char questionInput)
    {
        Console.Write($"Input ({playOption}) to Play or input ({questionInput}) to create Questions & Answers: ");
        char userSelection = Console.ReadKey().KeyChar;
        Console.Clear();
        
        return userSelection;
    }
}