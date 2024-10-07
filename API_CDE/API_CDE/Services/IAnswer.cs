using API_CDE.Models;

namespace API_CDE.Services
{
    public interface IAnswer
    {
        public IEnumerable<Answer> GetAnsersByIdQuestion(int idQuestion);
        public Answer AddAnswer(string content, int idQuestion);
        public Answer UpdateAnswer(int id, string content);
        public string DeleteAnswer(int id);
    }
}
