using System.Xml.Serialization;

namespace QuizMaker;

public class FileUtils
{
    public static void SaveData(QuestionsAndAnswers fileQuesAndAnswers)
    {
        
        XmlSerializer serializer = new XmlSerializer(typeof(QuestionsAndAnswers)); //Serialize instance data
        var path = CONSTANTS.SERIALIZER_PATH; //Serializer naming
        using (FileStream file = File.Create(path)) //Write data in path file
        {
            serializer.Serialize(file, fileQuesAndAnswers);
        }
        
    }

    public static QuestionsAndAnswers LoadData()
    {
        QuestionsAndAnswers returnValue;
        XmlSerializer deserializer = new XmlSerializer(typeof(QuestionsAndAnswers));
        string path = CONSTANTS.SERIALIZER_PATH; //Naming
        using (FileStream txtFile = File.OpenRead(path)) //Deserializing instance
        {
            returnValue = deserializer.Deserialize(txtFile) as QuestionsAndAnswers;
        }

        return returnValue;
    }
}