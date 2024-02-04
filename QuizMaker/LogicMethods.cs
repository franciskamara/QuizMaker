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
        QuestionsAndAnswers randomQuestion = null;//Print random Q&A 

        if (loadedQuesAndAnswers != null && loadedQuesAndAnswers.Count > 0)//Is there another way to handle this???
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