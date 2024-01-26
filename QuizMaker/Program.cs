using System.Net;
using System.Xml.Serialization;

namespace QuizMaker;

public class Program
{
    //User game selection constants
    public const char playOption = '1';
    public const char questionInput = '2';

    public static void Main()
    {
        UIMethods.PrintWelcomeMessage();

        char userSelection = UIMethods.PlayOrQuestionSelect();

        if (userSelection == questionInput)
        {
            int numberOfQuestions = UIMethods.InputNumberOfQuestions();
            int numberOfAnswers = UIMethods.InputNumberOfAnswers();

            List<QuestionsAndAnswers> ListQuesAndAnswers= new(); //Create a new Instance (List) of QuestionsAndAnswers object/class
            QuestionsAndAnswers FileQuesAndAnswers = new();
            
            for (int qInput = 0; qInput < numberOfQuestions; qInput++) //Loop: question input
            {

                FileQuesAndAnswers.question = UIMethods.InputQuestion();

                FileQuesAndAnswers.answers = UIMethods.InputAnswers(numberOfAnswers);

                FileQuesAndAnswers.correctAnswer = UIMethods.InputCorrectAnswerIndex();

                ListQuesAndAnswers.Add(FileQuesAndAnswers); //Add questions and answer(s) to list
                
                
            }
            FileUtils.SaveData(FileQuesAndAnswers);
        }

        if (userSelection == playOption)
        {
            //Random question generator
            List<string> qAndA = new();
            Random random = new Random();
            // string randomQuestion = random.ToString();
        }

        else
        {
            Console.WriteLine("Invalid selection");
            return;
        }
    }
}