namespace QuizMaker;

public class LogicMethods
{
    public static QuestionsAndAnswers RandomQuestionGenerator(List<QuestionsAndAnswers> loadedQuesAndAnswers)
    {
        QuestionsAndAnswers randomQuestion = null;

        if (loadedQuesAndAnswers != null && loadedQuesAndAnswers.Count > 0)
        {
            Random random = new Random();
            randomQuestion = loadedQuesAndAnswers[random.Next(loadedQuesAndAnswers.Count)];
        }
        else
        {
            Console.WriteLine("No questions available. Please add questions before playing.");
            // You may want to handle this case appropriately, e.g., allow the user to add questions
        }

        return randomQuestion;
    }
}