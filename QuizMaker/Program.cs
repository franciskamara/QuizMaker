﻿using System.Net;
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

            List<QuestionsAndAnswers> qList = new(); //Create a new Instance (List) of QuestionsAndAnswers object/class

            for (int qInput = 0; qInput < numberOfQuestions; qInput++) //Loop: question input
            {
                QuestionsAndAnswers qAndA = new();

                UIMethods.QuestionInput();

                for (int aInput = 0; aInput < numberOfAnswers; aInput++) //Loop: answers input
                {
                    UIMethods.InputAnswers(aInput);
                    // Console.Write($"Input answer {aInput + 1}: ");
                    // qAndA.answers.Add(Console.ReadLine());
                    // Console.Clear();
                }

                UIMethods.InputCorrectAnswerIndex();
                // Console.Write("Choose the correct answer index: ");
                // qAndA.correctAnswer = Int32.Parse(Console.ReadLine()); //Correct answer index input
                // Console.Clear();


                qList.Add(qAndA); //Add instance

                XmlSerializer serializer = new XmlSerializer(typeof(QuestionsAndAnswers)); //Serialize instance data
                var path = @"QuestionsAndAnswersList.xml"; //Naming
                using (FileStream file = File.Create(path)) //Write data in path file
                {
                    serializer.Serialize(file, qAndA);
                }

                using (FileStream txtFile = File.OpenRead(path)) //Deserializing instance
                {
                    qAndA = serializer.Deserialize(txtFile) as QuestionsAndAnswers;
                }

                // Console.WriteLine(qAndA.Question); //Print question
                // foreach (string answer in qAndA.answers) //Print each answer 
                // {
                //     Console.WriteLine(answer);
                // }
            }
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