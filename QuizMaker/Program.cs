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

            List<QuestionsAndAnswers> listQuesAndAnswers = new(); // Create a new Instance (List) of QuestionsAndAnswers object/class

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