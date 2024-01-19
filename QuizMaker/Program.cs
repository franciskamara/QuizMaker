﻿using System.Net;
using System.Xml.Serialization;

namespace QuizMaker;

public class Program
{
    public static void Main()
    {
        const char playOption = '1';
        const char questionInput = '2';
        
        UIMethods.PrintWelcomeMessage();

        char userSelection = UIMethods.PlayOrQuestionSelect(playOption, questionInput);
        // Console.Write($"Input ({playOption}) to Play or input ({questionInput}) to create Questions & Answers: ");
        // char userSelection = Console.ReadKey().KeyChar;
        // Console.Clear();

        if (userSelection == questionInput)
        {
            Console.Write("How many questions do you wish to include? ");
            int numberOfQuestions = int.Parse(Console.ReadLine()); //Quantity of questions to input
            Console.Write("How many answers do you want to include for your questions? ");
            int numberOfAnswers = int.Parse(Console.ReadLine()); //Quantity of answer options to input 
            Console.Clear();

            List<QuestionsAndAnswers> qList = new(); //Create a new Instance (List) of QuestionsAndAnswers object/class

            for (int qInput = 0; qInput < numberOfQuestions; qInput++) //Loop: question input
            {
                QuestionsAndAnswers qAndA = new();
                Console.Write("Input the question: ");
                qAndA.Question = Console.ReadLine();
                Console.Clear();

                for (int aInput = 0; aInput < numberOfAnswers; aInput++) //Loop: answers input
                {
                    Console.Write($"Input answer {aInput + 1}: ");
                    qAndA.answers.Add(Console.ReadLine());
                    Console.Clear();
                }

                Console.Write("Choose the correct answer index: ");
                qAndA.correctAnswer = Int32.Parse(Console.ReadLine()); //Correct answer index input
                Console.Clear();


                qList.Add(qAndA); //Add instance

                XmlSerializer serializer = new XmlSerializer(typeof(QuestionsAndAnswers)); //Serialize instance data
                var path = @"QuestionsAndAnswersList.xml"; //Naming
                using (FileStream file = File.Create(path)) //Write data in path file
                {
                    serializer.Serialize(file, qAndA);
                }

                using (FileStream file = File.OpenRead(path)) //Deserializing instance
                {
                    qAndA = serializer.Deserialize(file) as QuestionsAndAnswers;
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
            //Random quesiton generator
            Random random = new Random();
            string randomQuestion = random.ToString();
        }

        else
        {
            Console.WriteLine("Invalid selection");
            return;
        }
    }
}