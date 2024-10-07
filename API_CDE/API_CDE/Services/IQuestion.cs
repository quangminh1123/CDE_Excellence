using API_CDE.Models;

namespace API_CDE.Services
{
    public interface IQuestion
    {
        public string GetQuestionsByIdSuAr(int idSuAr);
        public string GetQuestion(int id);
        public Question AddQuestion(string content, bool isMultipleChoice, int idSuAr);
        public Question UpdateQuestion(int id, string content, bool isMultipleChoice);
        public string DeleteQuestion(int id);

    }
}
