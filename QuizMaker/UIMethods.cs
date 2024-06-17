using System.Net;

namespace QuizMaker;

public class UIMethods
{
    /// <summary>
    /// Quiz Maker welcome message
    /// </summary>
    public static void PrintWelcomeMessage()
    {
        Console.WriteLine(" Welcome to the Quiz Maker ");
        Console.WriteLine("****************************");
        Console.WriteLine();
    }

    /// <summary>
    /// Question for user to Play or Input Questions/Answers
    /// </summary>
    /// <returns>User selection</returns>
    public static int PlayOrQuestionSelect()
    {
        while (true)
        {
            Console.Write(
                $"Input ({CONSTANTS.PLAY_INPUT_OPTION}) to Play \nInput ({CONSTANTS.QUESTION_INPUT_OPTION}) to create Questions & Answers: ");

            if (Int32.TryParse(Console.ReadLine(), out int userSelection))
            {
                Console.Clear();
                return userSelection;
            }

            Console.Clear();
            Console.WriteLine("Invalid input. Please try again.");
        }
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
    public static string InputQuestion(int qInput)
    {
        Console.Clear();
        Console.Write($"Input question no.{qInput + 1}: ");
        string question = Console.ReadLine();
        Console.Clear();

        return question;
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
            Console.Write($"Input answer No.{aInput + 1}: ");
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
        int correctAnswerIndex;
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

                Console.WriteLine(
                    $"The correct answer index should be between 0 and less than {numberOfAnswers}.");
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
    /// <param name="randomQ"></param>
    public static void PrintQuestionAndAnswers(QuestionsAndAnswers randomQ)
    {
        Console.WriteLine($"Question: {randomQ.Question}"); //Print the random question 

        Console.WriteLine("Optional answers: "); //Print the answers for the question 
        for (int answerCount = 0; answerCount < randomQ.Answers.Count; answerCount++)
        {
            Console.WriteLine($"{answerCount + 1}: {randomQ.Answers[answerCount]}");
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
        Console.WriteLine("Invalid selection. Please try again.");
    }

    /// <summary>
    /// User input answer selection
    /// </summary>
    /// <param name="randomQAndA"></param>
    /// <returns>Answer input</returns>
    public static int AnswerInput(QuestionsAndAnswers randomQAndA)
    {
        while (true)
        {
            Console.WriteLine();
            Console.Write("What is your answer no.? ");

            if (Int32.TryParse(Console.ReadLine(), out int userAnswer))
            {
                return userAnswer;
            }

            Console.WriteLine("Invalid input. Please try again.");
        }

        // return userAnswer;
    }

    /// <summary>
    /// Outcome from the answer is printed out along with Points total
    /// </summary>
    /// <param name="userAnswer"></param>
    /// <param name="randomQAndA"></param>
    /// <param name="points"></param>
    /// <returns>Point addition</returns>
    public static int AnswerResult(int userAnswer, QuestionsAndAnswers randomQAndA, int points)
    {
        int indexReduction = 1;
        if (userAnswer - indexReduction == randomQAndA.correctAnswerIndex)
        {
            Console.Clear();
            Console.WriteLine("Correct answer");
            points += 1;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Incorrect answer");
        }

        return points;
    }

    /// <summary>
    /// Ask user if they wish to continue playing
    /// </summary>
    /// <returns>User's answer</returns>
    public static string continuePlaying()
    {
        while (true)
        {
            Console.Write("Do you wish to continue playing? y/n: ");
            string continuePlay = Console.ReadLine().ToLower();
            if (continuePlay == CONSTANTS.OPTION_YES)
            {
                return continuePlay;
            }

            if (continuePlay == CONSTANTS.OPTION_NO)
            {
                return continuePlay;
            }

            Console.WriteLine("\nIncorrect option. Please try again. ");
        }
    }

    /// <summary>
    /// End game play message
    /// </summary>
    public static void ThanksForPlayingMessage(int points)
    {
        Console.Clear();
        Console.WriteLine($"Thanks for playing. Total points: {points}");
    }
    
    /// <summary>
    /// Print points total to user
    /// </summary>
    /// <param name="points"></param>
    public static void PrintPoints(int points)
    {
        Console.WriteLine($"Points: {points}");
    }

    /// <summary>
    /// Request user make another input
    /// </summary>
    public static void RequestAnotherInput()
    {
        Console.Write("Please make another input: ");
    }
    
    /// <summary>
    /// User makes an invalid input, request a valid input 
    /// </summary>
    /// <returns>The user's selection</returns>
    public static int InvalidOptionNewSelection()
    {
        int userSelection;
        UIMethods.InvalidSelectionMessage();
        UIMethods.RequestAnotherInput();
        while (true)
        {
            if (Int32.TryParse(Console.ReadLine(), out userSelection))
            {
                if (userSelection != CONSTANTS.PLAY_INPUT_OPTION ||
                    userSelection != CONSTANTS.QUESTION_INPUT_OPTION)
                {
                    break;
                }
            }
            else
            {
                UIMethods.InvalidSelectionMessage();
            }
        }
        return userSelection;
    }
}