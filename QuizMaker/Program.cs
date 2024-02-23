using System.Net;
using System.Xml.Serialization;

namespace QuizMaker;

public class Program
{
    public static void Main()
    {
        UIMethods.PrintWelcomeMessage();

        int userSelection = UIMethods.PlayOrQuestionSelect();

        if (userSelection == CONSTANTS.PLAY_INPUT_OPTION)
        {
            List<QuestionsAndAnswers>
                loadedQAndA = FileUtils.LoadData(); //Load Q&A from LoadData serialisation

            if (loadedQAndA != null && loadedQAndA.Count > 0)
            {
                int points = 0;
                while (loadedQAndA.Count > 0)
                {
                    // Pull randomly selected question and answers 
                    QuestionsAndAnswers randomQAndA = LogicMethods.RandomQuestionGenerator(loadedQAndA);

                    if (randomQAndA != null)
                    {
                        UIMethods.PrintQuestionAndAnswers(randomQAndA); //Print Random Q&A from the list

                        //loadedQAndA.Remove(randomQ); // Remove the selected question from the list

                        int userAnswer = UIMethods.AnswerInput(randomQAndA); //User makes an answer input
                        //if statement: answer is 0
                        if (userAnswer == 0)
                            return; //print goodbye message and exit
                        points = UIMethods.AnswerResult(userAnswer, randomQAndA, points); //Outcome from user answer

                        LogicMethods.PrintPoints(points);
                    }
                    else
                    {
                        UIMethods.NoQuestionsAvailableMessage(); //Question unavailable for gameplay message
                        //May need to add more or handle different 
                    }
                }
            }

            if (loadedQAndA.Count == 0)
            {
                UIMethods.NoQuestionsAvailableMessage(); //Question unavailable for gameplay message
                return;
                //May need to add more or handle different 
            }
        } //End: Play option

        if (userSelection == CONSTANTS.QUESTION_INPUT_OPTION)
        {
            int numberOfQuestions = UIMethods.InputNumberOfQuestions();
            int numberOfAnswers = UIMethods.InputNumberOfAnswers();

            List<QuestionsAndAnswers>
                listQuesAndAnswers = new(); // Create a new Instance (List) of QuestionsAndAnswers object/class

            for (int qInput = 0; qInput < numberOfQuestions; qInput++) // Loop: question input
            {
                QuestionsAndAnswers questionsAndAnswersSet = new();

                questionsAndAnswersSet.Question = UIMethods.InputQuestion(qInput); //User input the question 

                questionsAndAnswersSet.Answers =
                    UIMethods.InputAnswers(numberOfAnswers); //User input the range of possible answers

                questionsAndAnswersSet.correctAnswerIndex =
                    UIMethods.InputCorrectAnswerIndex(numberOfAnswers); //User inputs the index of correct answer

                listQuesAndAnswers.Add(questionsAndAnswersSet); //Add questions and answer(s) to list
            }

            FileUtils.SaveData(listQuesAndAnswers); //Save the entire list
        } //End: Q&A input option
        // else
        // {
        //     UIMethods.InvalidSelectionMessage();
        //     Console.Write("Please make another input: ");
        //     while (true)
        //     {
        //         if (Int32.TryParse(Console.ReadLine(), out userSelection))
        //         {
        //             break;
        //         }
        //         else
        //         {
        //             UIMethods.InvalidSelectionMessage();
        //             Console.Write("Please make another input: ");
        //         }
        //     }
        //     //You may need to handle this seperately!!
        // }
    }
}