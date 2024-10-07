using API_CDE.Data;
using API_CDE.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace API_CDE.Services
{
    public class AccountAnswerResponse : IAccountAnswer
    {
        private readonly ApplicationDBContext _context;
        public AccountAnswerResponse(ApplicationDBContext context) => _context = context;
        public AccountAnswer AddAccountAnswer(int idQuestion, int idAnswer, int idAccount)
        {
            try
            {
                var acAn = new AccountAnswer()
                {
                    IdQuestion = idQuestion,
                    IdAnswer = idAnswer,
                    IdAcc = idAccount
                };
                _context.AccountAnswers.Add(acAn);
                _context.SaveChanges();
                return acAn;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public IEnumerable<AccountAnswer> GetByIdQuestion(int idQuestion)
        {
            //var options = new JsonSerializerOptions
            //{
            //    ReferenceHandler = ReferenceHandler.Preserve,
            //    WriteIndented = true
            //};
            var acAn = _context.AccountAnswers.Where(x => x.IdQuestion == idQuestion).ToList();
            return acAn;
        }
    }
}
