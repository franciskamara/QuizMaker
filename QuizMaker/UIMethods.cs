using System.Net;

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
            $"Input ({CONSTANTS.PLAY_OPTION_INPUT}) to Play \nInput ({CONSTANTS.QUESTION_INPUT_OPTION}) to create Questions & Answers: ");
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
    /// User question input
    /// </summary>
    /// <returns>User question input</returns>
    public static List<string> InputQuestions()
    {
        Console.Clear();
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
            Console.Write($"Input answer no.{aInput + 1}: ");
            answers.Add(Console.ReadLine());
            Console.Clear();
        }

        return answers;
    }

    /// <summary>
    /// User input the correct answer's index
    /// </summary>
    /// <returns>Correct answer index</returns>
    public static int InputCorrectAnswerIndex(int numberOfAnswers)
    {
        int correctAnswerIndex = 0;

        while (true) //While loop: infinite until correct input is made
        {
            Console.Write("Please enter the correct answer index: ");
            if (Int32.TryParse(Console.ReadLine(), out correctAnswerIndex))
            {
                if (correctAnswerIndex < numberOfAnswers)
                {
                    Console.Clear();
                    break; //Exit the loop if the input is valid and less than numberOfAnswers
                }
                else
                {
                    Console.WriteLine(
                        $"The correct answer index should be between 0 and less than {numberOfAnswers}.");
                }
            }
            else
            {
                Console.WriteLine("The input is not valid.");
            }
        }

        return correctAnswerIndex;
    }

    /// <summary>
    /// Gameplay: Print a Question with its Answers
    /// </summary>
    /// <param name="randomQuestion"></param>
    public static void PrintQuestionAndAnswers(QuestionsAndAnswers randomQuestion)
    {
        Console.Write("Q: "); //Print the random question 
        foreach (string question in randomQuestion.questions)
        {
            Console.WriteLine(question);
        }

        Console.WriteLine("Pick your answer: "); //Print the answers for the question 
        foreach (string answer in randomQuestion.answers)
        {
            Console.WriteLine($"- {answer}");
        }
    }

    /// <summary>
    /// Notify user that no questions have been saved to play the game 
    /// </summary>
    public static void NoQuestionsAvailableMessage()
    {
        Console.WriteLine("No questions available. Please add questions before playing.");
    }

    /// <summary>
    /// Notify user that they have picked a wrong option from Game play to Q&A input
    /// </summary>
    public static void InvalidSelectionMessage()
    {
        Console.WriteLine("Invalid selection");
    }
}