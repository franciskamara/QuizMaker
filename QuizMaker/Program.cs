﻿using System.Net;
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

                questionsAndAnswersSet.questions = UIMethods.InputQuestions();

                questionsAndAnswersSet.answers = UIMethods.InputAnswers(numberOfAnswers);

                questionsAndAnswersSet.correctAnswer = UIMethods.InputCorrectAnswerIndex();

                listQuesAndAnswers.Add(questionsAndAnswersSet); // Add questions and answer(s) to list
            }

            FileUtils.SaveData(listQuesAndAnswers); // Save the entire list
        }

        if (userSelection == CONSTANTS.PLAY_OPTION)
        {
            List<QuestionsAndAnswers> loadedQuesAndAnswers = FileUtils.LoadData();

            if (loadedQuesAndAnswers != null && loadedQuesAndAnswers.Count > 0)
            {
                // Pull randomly selected question and answers 
                QuestionsAndAnswers randomQuestion = LogicMethods.RandomQuestionGenerator(loadedQuesAndAnswers);

                if (randomQuestion != null)
                {
                    Console.WriteLine("Question: " + randomQuestion.questions);// Display the random question and its associated answers

                    Console.WriteLine("Answers:");
                    foreach (string answer in randomQuestion.answers)
                    {
                        Console.WriteLine("- " + answer);
                    }
                    
                    loadedQuesAndAnswers.Remove(randomQuestion); // Remove the selected question from the list
                }
                else
                {
                    UIMethods.NoQuestionsAvailableMessage();
                    // Handle this case appropriately, e.g., allow the user to add questions
                }
            }
            else
            {
                UIMethods.NoQuestionsAvailableMessage();
                // Handle this case appropriately, e.g., allow the user to add questions
            }
        }

        if (userSelection != CONSTANTS.QUESTION_INPUT_OPTION && userSelection != CONSTANTS.PLAY_OPTION)
        {
            UIMethods.InvalidSelectionMessage();
            return;
        }
    }
}