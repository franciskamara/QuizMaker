using System.Xml.Serialization;

namespace QuizMaker;

public class FileUtils
{
    public static void SaveData(List<QuestionsAndAnswers> listQuesAndAnswers)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<QuestionsAndAnswers>)); // Serialize list data
        string path = CONSTANTS.SERIALIZER_PATH; // Serializer naming
        using (FileStream file = File.Create(path)) // Write data to the file
        {
            serializer.Serialize(file, listQuesAndAnswers);
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