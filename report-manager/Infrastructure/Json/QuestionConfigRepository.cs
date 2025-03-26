using Newtonsoft.Json;

namespace ReportManager.Infrastructure.Json;

public interface IQuestionConfigRepository
{
    List<QuestionConfig> Find(string filePath);
}

public class QuestionConfigRepository : IQuestionConfigRepository
{
    public List<QuestionConfig> Find(string filePath) =>
        JsonConvert.DeserializeObject<List<QuestionConfig>>(File.ReadAllText(filePath));
}
