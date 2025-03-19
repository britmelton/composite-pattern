using Newtonsoft.Json;

namespace Report_Manager;

public interface IQuestionConfigRepository
{
    List<QuestionConfig> Get(string filePath);
}

public class QuestionConfigRepository : IQuestionConfigRepository
{
    public List<QuestionConfig> Get(string filePath) =>
        JsonConvert.DeserializeObject<List<QuestionConfig>>(File.ReadAllText(filePath));
}
