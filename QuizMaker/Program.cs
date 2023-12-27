namespace QuizMaker;

public class Program
{
    public void Main()
    {
        Console.WriteLine("Welcome to the Quiz Maker");

        Console.Write("How many questions do you wish to include? ");
        int numberOfQuestions = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.Write("How many answers do you want to include for your questions? ");
        int numberOfAnswers = int.Parse(Console.ReadLine());
        Console.Clear();

        for (int qInput = 0; qInput < numberOfQuestions; qInput++)//Loops for Q and A input
        {
            List<QuestionsAndAnswers> qList = new();
            QuestionsAndAnswers qOne = new();
            qOne.Question = Console.ReadLine();
            Console.Clear();

            for (int aInput = 0; aInput < numberOfAnswers; aInput++)
            {
                qOne.answerOne = Console.ReadLine();
                qOne.answerTwo = Console.ReadLine();
                qOne.answerThree = Console.ReadLine();
                qOne.answerFour = Console.ReadLine();
                qOne.correctAnswer = Console.ReadLine();
            }

            qList.Add(qOne);

        }
    }
}
