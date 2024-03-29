namespace QuizMaker;

public class LogicMethods
{
    /// <summary>
    /// Generator of Q&A from XML and structure using QuestionsAndAnswers class
    /// </summary>
    /// <param name="loadedQAndA"></param>
    /// <returns>A random question, if questions are available</returns>
    public static QuestionsAndAnswers GenerateRandomQuestions(List<QuestionsAndAnswers> loadedQAndA)
    {
        QuestionsAndAnswers randomQAndA = null;

        if (loadedQAndA != null && loadedQAndA.Count > 0)
        {
            Random rng = new Random();
            randomQAndA = loadedQAndA[rng.Next(loadedQAndA.Count)]; //Print random Q&A
        }
        else
        {
            Console.WriteLine("No questions available. Please add questions before playing.");
        }

        return randomQAndA;
    }
    
}