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

    /// <summary>
    /// Return the data from the XML and structures with QuestionsAndAnswers class 
    /// </summary>
    /// <returns>List of questions ans answers</returns>
    public static List<QuestionsAndAnswers> LoadData()
    {
        List<QuestionsAndAnswers> returnValue;
        XmlSerializer deserializer = new XmlSerializer(typeof(List<QuestionsAndAnswers>));
        string path = CONSTANTS.SERIALIZER_PATH; //Naming
        using (FileStream txtFile = File.OpenRead(path)) //Deserializing list
        {
            returnValue = deserializer.Deserialize(txtFile) as List<QuestionsAndAnswers>;
        }

        return returnValue;
        
        //May need to add more here!
    }
    
}