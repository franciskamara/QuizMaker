namespace QuizMaker;

public class UIMethods
{
    /// <summary>
    /// Quiz Maker welcome message
    /// </summary>
    public static void PrintWelcomeMessage()
    {
        Console.WriteLine(" Welcome to the Quiz Maker");
        Console.WriteLine("****************************");
        Console.WriteLine();
    }
    
    /// <summary>
    /// Question for user to Play or Input Questions/Answers
    /// </summary>
    /// <returns>User selection</returns>
    public static char PlayOrQuestionSelect()
    {
        Console.Write($"Input ({Program.playOption}) to Play or input ({Program.questionInput}) to create Questions & Answers: ");
        char userSelection = Console.ReadKey().KeyChar;
        Console.Clear();
        
        return userSelection;
    }

    /// <summary>
    /// Question/Answers sequence: Number of questions to input
    /// </summary>
    /// <returns>Quantity input for question(s)</returns>
    public static int InputNumberOfQuestions()
    {
        Console.Write("How many questions do you wish to include? ");
        int numberOfQuestions = int.Parse(Console.ReadLine()); //Quantity of questions to input
        
        return numberOfQuestions;
    }

    /// <summary>
    /// Question/Answers sequence: Number of answers to input
    /// </summary>
    /// <returns>Quantity input for answers</returns>
    public static int InputNumberOfAnswers()
    {
        Console.Write("How many answers do you want to include for your questions? ");
        int numberOfAnswers = int.Parse(Console.ReadLine()); //Quantity of answer options to input 
        Console.Clear();

        return numberOfAnswers;
    }

    /// <summary>
    /// User input question 
    /// </summary>
    /// <returns>Question innput</returns>
    public static string QuestionInput()
    {
        QuestionsAndAnswers qAndA = new();
        Console.Write("Input the question: ");
        qAndA.Question = Console.ReadLine();
        Console.Clear();

        return qAndA.Question;
    }

    // public static string AnswersInput()
    // {
    //     
    //     Console.Write($"Input answer {aInput + 1}: ");
    //     qAndA.answers.Add(Console.ReadLine());
    //     Console.Clear();
    // }
}