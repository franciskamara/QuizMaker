using System.Xml.Serialization;

namespace QuizMaker;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Welcome to the Quiz Maker");

        Console.Write("How many questions do you wish to include? ");
        int numberOfQuestions = int.Parse(Console.ReadLine());
        Console.Write("How many answers do you want to include for your questions? ");
        int numberOfAnswers = int.Parse(Console.ReadLine());
        Console.Clear();
            
        List<QuestionsAndAnswers> qList = new();

        for (int qInput = 0; qInput < numberOfQuestions; qInput++)//Loops for Q and A input
        {
            
            QuestionsAndAnswers qAndA = new();
            Console.Write("Input the question: ");
            qAndA.Question = Console.ReadLine();
            Console.Clear();

            for (int aInput = 0; aInput < numberOfAnswers; aInput++)
            {
                Console.Write($"Input answer {aInput +1}: ");
                qAndA.answers.Add( Console.ReadLine());
                Console.Clear();
                
            }

            Console.Write("Choose the correct answer index: ");
            qAndA.correctAnswer = Int32.Parse(Console.ReadLine());
            
            qList.Add(qAndA);
            Console.WriteLine(qAndA.Question);

            foreach (string answer in qAndA.answers)
            {
                Console.WriteLine(answer);   
            }

            XmlSerializer writer = new XmlSerializer(typeof(QuestionsAndAnswers));
            var path = @"QuestionsAndAnswersList.xml";
            using (FileStream file = File.Create(path))
            {
                writer.Serialize(file, qAndA);
            }

        }
    }
}
