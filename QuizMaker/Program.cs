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
                listQuesAndAnswers = new(); // Create a new Instance (List) of QuestionsAndAnswers object/class

            for (int qInput = 0; qInput < numberOfQuestions; qInput++) // Loop: question input
            {
                QuestionsAndAnswers questionsAndAnswersSet = new();

                questionsAndAnswersSet.questions = UIMethods.InputQuestions();//User input the question 

                questionsAndAnswersSet.answers = UIMethods.InputAnswers(numberOfAnswers);//User input the range of possible answers

                questionsAndAnswersSet.correctAnswer = UIMethods.InputCorrectAnswerIndex(numberOfAnswers);//User inputs the index of correct answer

                listQuesAndAnswers.Add(questionsAndAnswersSet); //Add questions and answer(s) to list
            }

            FileUtils.SaveData(listQuesAndAnswers); //Save the entire list
        }

        if (userSelection == CONSTANTS.PLAY_OPTION_INPUT)
        {
            List<QuestionsAndAnswers> loadedQuesAndAnswers = FileUtils.LoadData();//Load Q&A from LoadData serialisation

            if (loadedQuesAndAnswers != null && loadedQuesAndAnswers.Count > 0)
            {
                // Pull randomly selected question and answers 
                QuestionsAndAnswers randomQuestion = LogicMethods.RandomQuestionGenerator(loadedQuesAndAnswers);

                if (randomQuestion != null)
                {
                    UIMethods.PrintQuestionAndAnswers(randomQuestion);//Print Random Q&A from the list

                    loadedQuesAndAnswers.Remove(randomQuestion); // Remove the selected question from the list
                }
                else
                {
                    UIMethods.NoQuestionsAvailableMessage();//Question unavailable for gameplay message
                    //May need to add more or handle different 
                    
                }
            }
            else
            {
                UIMethods.NoQuestionsAvailableMessage();//Question unavailable for gameplay message
                //May need to add more or handle different 
               
            }
        }

        if (userSelection != CONSTANTS.QUESTION_INPUT_OPTION && userSelection != CONSTANTS.PLAY_OPTION_INPUT)
        {
            UIMethods.InvalidSelectionMessage();
            //You may need to handle this seperately!!
            return;
        }
    }
}