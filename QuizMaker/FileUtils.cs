using System.Xml.Serialization;

namespace QuizMaker;

public class FileUtils
{
    public static void xmlSerializer()
    {
        QuestionsAndAnswers qAndA = new();
        XmlSerializer serializer = new XmlSerializer(typeof(QuestionsAndAnswers)); //Serialize instance data
        var path = @"QuestionsAndAnswersList.xml"; //Naming
        using (FileStream file = File.Create(path)) //Write data in path file
        {
            serializer.Serialize(file, qAndA);
        }
        
        using (FileStream txtFile = File.OpenRead(path)) //Deserializing instance
        {
            qAndA = serializer.Deserialize(txtFile) as QuestionsAndAnswers;
        }
    }
}