using API_CDE.Data;
using API_CDE.Models;

namespace API_CDE.Services
{
    public class AccountSurveyRequestResponse : IAccountSurveyRequest
    {
        private readonly ApplicationDBContext _context;
        public AccountSurveyRequestResponse(ApplicationDBContext context) => _context = context;
        public AccountSurveyRequest Add(int idSurveyRequest, int idAccount)
        {
            try
            {
                var acSuRe = new AccountSurveyRequest()
                {
                    IdSuRe = idSurveyRequest,
                    IdAcc = idAccount
                };
                _context.AccountSurveyRequests.Add(acSuRe);
                _context.SaveChanges();
                return acSuRe;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<AccountSurveyRequest> List()
        {
            return _context.AccountSurveyRequests;
        }
    }
}
