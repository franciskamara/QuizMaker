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

        for (int qInput = 0; qInput < numberOfQuestions; qInput++)//Loops for Q and A input
        {
            List<QuestionsAndAnswers> qList = new();
            List<QuestionsAndAnswers> aList = new();
            
            QuestionsAndAnswers qAndA = new();
            Console.Write("Input the question: ");
            qAndA.Question = Console.ReadLine();
            Console.Clear();

            for (int aInput = 0; aInput < numberOfAnswers; aInput++)
            {
                Console.Write($"Input answer {aInput +1}: ");
                qAndA.answers = Console.ReadLine();
                Console.Clear();
                
            }

            Console.Write("Input the correct answer: ");
            qAndA.correctAnswer = Console.ReadLine();
            
            qList.Add(qAndA);
            // aList.Add();
            Console.WriteLine(qAndA.Question);
            Console.WriteLine();
        }
    }
}
