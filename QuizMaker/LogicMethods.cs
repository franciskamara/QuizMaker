namespace QuizMaker;

public class LogicMethods
{
    public static QuestionsAndAnswers RandomQuestionGenerator(List<QuestionsAndAnswers> loadedQuesAndAnswers)
    {
        QuestionsAndAnswers randomQuestion = null;//Print random Q&A 

        if (loadedQuesAndAnswers != null && loadedQuesAndAnswers.Count > 0)
        {
            Random rng = new Random();
            randomQuestion = loadedQuesAndAnswers[rng.Next(loadedQuesAndAnswers.Count)];
        }
        else
        {
            Console.WriteLine("No questions available. Please add questions before playing.");
        }

        return randomQuestion;
    }
}