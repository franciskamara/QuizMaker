namespace QuizMaker;

public class LogicMethods
{
    /// <summary>
    /// Generator of Q&A from XML and structure using  QuestionsAndAnswers class
    /// </summary>
    /// <param name="loadedQuesAndAnswers"></param>
    /// <returns>A random question, if questions are available</returns>
    public static QuestionsAndAnswers RandomQuestionGenerator(List<QuestionsAndAnswers> loadedQuesAndAnswers)
    {
        QuestionsAndAnswers randomQuestion = null; 

        if (loadedQuesAndAnswers != null && loadedQuesAndAnswers.Count > 0)
        {
            Random rng = new Random();
            randomQuestion = loadedQuesAndAnswers[rng.Next(loadedQuesAndAnswers.Count)];//Print random Q&A
        }
        else
        {
            Console.WriteLine("No questions available. Please add questions before playing.");
        }

        return randomQuestion;
    }
}