using API_CDE.Models;

namespace API_CDE.Services
{
    public interface IAccountAnswer
    {
        public IEnumerable<AccountAnswer> GetByIdQuestion(int idQuestion);

        public AccountAnswer AddAccountAnswer(int idQuestion, int idAnswer, int idAccount);
    }
}
