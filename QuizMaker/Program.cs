using System.Net;
using System.Xml.Serialization;

namespace QuizMaker;

public class Program
{
    public static void Main()
    {
        UIMethods.PrintWelcomeMessage();

        char userSelection = UIMethods.PlayOrQuestionSelect();


        if (userSelection == CONSTANTS.QUESTION_INPUT_OPTION)
        {
            int numberOfQuestions = UIMethods.InputNumberOfQuestions();
            int numberOfAnswers = UIMethods.InputNumberOfAnswers();

            List<QuestionsAndAnswers>
                listQuesAndAnswers = new(); //Create a new Instance (List) of QuestionsAndAnswers object/class

            for (int qInput = 0; qInput < numberOfQuestions; qInput++) //Loop: question input
            {
                QuestionsAndAnswers fileQuesAndAnswers = new();
                fileQuesAndAnswers.questions = UIMethods.InputQuestions();

                fileQuesAndAnswers.answers = UIMethods.InputAnswers(numberOfAnswers);

                fileQuesAndAnswers.correctAnswer = UIMethods.InputCorrectAnswerIndex();

                listQuesAndAnswers.Add(fileQuesAndAnswers); //Add questions and answer(s) to list
            }

            FileUtils.SaveData(fileQuesAndAnswers);
        }


        if (userSelection == CONSTANTS.PLAY_OPTION)
        {
            //Random question generator
            List<string> qAndA = new();
            Random random = new Random();
            // string randomQuestion = random.ToString();
        }

        if (userSelection != CONSTANTS.QUESTION_INPUT_OPTION && userSelection != CONSTANTS.PLAY_OPTION)
        {
            Console.WriteLine("Invalid selection");
            return;
        }
    }
}