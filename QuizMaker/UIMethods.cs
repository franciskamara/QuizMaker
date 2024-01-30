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
        Console.Write(
            $"Input ({Program.PLAY_OPTION}) to Play or input ({Program.QUESTION_INPUT_OPTION}) to create Questions & Answers: ");
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
    public static List<string> InputQuestion()
    {
        List<string> questions = new();
        Console.Write("Input the question: ");
        questions.Add(Console.ReadLine());
        Console.Clear();

        return questions;
    }

    /// <summary>
    /// List of answers to input
    /// </summary>
    /// <param name="numberOfAnswers">Quantity of answers to be inputted</param>
    /// <returns>List of answers</returns>
    public static List<string> InputAnswers(int numberOfAnswers)
    {
        List<string> answers = new();
        for (int aInput = 0; aInput < numberOfAnswers; aInput++) //Loop: answers input
        {
            Console.Write($"Input answer {aInput + 1}: ");
            answers.Add(Console.ReadLine());
            Console.Clear();
        }

        return answers;
    }

    /// <summary>
    /// User input the correct answer's index
    /// </summary>
    /// <returns>Correct answer index</returns>
    public static int InputCorrectAnswerIndex()
    {
        Console.Write("Choose the correct answer index: ");
        int correctAnswer = Int32.Parse(Console.ReadLine()); //Correct answer index input
        Console.Clear();

        return correctAnswer;
    }
}