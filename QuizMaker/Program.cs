using System.Net;
using System.Xml.Serialization;

namespace QuizMaker;

public class Program
{
    //User game selection constants
    public const char PLAY_OPTION = '1';
    public const char QUESTION_INPUT_OPTION = '2';

    public static void Main()
    {
        UIMethods.PrintWelcomeMessage();

        char userSelection = UIMethods.PlayOrQuestionSelect();


        if (userSelection == QUESTION_INPUT_OPTION)
        {
            int numberOfQuestions = UIMethods.InputNumberOfQuestions();
            int numberOfAnswers = UIMethods.InputNumberOfAnswers();

            List<QuestionsAndAnswers>
                ListQuesAndAnswers = new(); //Create a new Instance (List) of QuestionsAndAnswers object/class

            for (int qInput = 0; qInput < numberOfQuestions; qInput++) //Loop: question input
            {
                QuestionsAndAnswers FileQuesAndAnswers = new();
                FileQuesAndAnswers.questions = UIMethods.InputQuestion();

                FileQuesAndAnswers.answers = UIMethods.InputAnswers(numberOfAnswers);

                FileQuesAndAnswers.correctAnswer = UIMethods.InputCorrectAnswerIndex();

                ListQuesAndAnswers.Add(FileQuesAndAnswers); //Add questions and answer(s) to list
            }

            FileUtils.SaveData(FileQuesAndAnswers);
        }


        if (userSelection == PLAY_OPTION)
        {
            //Random question generator
            List<string> qAndA = new();
            Random random = new Random();
            // string randomQuestion = random.ToString();
        }

        if (userSelection != QUESTION_INPUT_OPTION && userSelection != PLAY_OPTION)
        {
            Console.WriteLine("Invalid selection");
            return;
        }
    }
}