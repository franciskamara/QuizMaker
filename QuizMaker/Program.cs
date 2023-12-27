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
            QuestionsAndAnswers questionEntry = new();
            Console.Write("Input the question: ");
            questionEntry.Question = Console.ReadLine();
            Console.Clear();

            for (int aInput = 0; aInput < numberOfAnswers; aInput++)
            {
                Console.Write($"Input answer {aInput +1}: ");
                questionEntry.answerOne = Console.ReadLine();
                // questionEntry.answerTwo = Console.ReadLine();
                // questionEntry.answerThree = Console.ReadLine();
                // questionEntry.answerFour = Console.ReadLine();
                // questionEntry.correctAnswer = Console.ReadLine();
            }

            qList.Add(questionEntry);

        }
    }
}
