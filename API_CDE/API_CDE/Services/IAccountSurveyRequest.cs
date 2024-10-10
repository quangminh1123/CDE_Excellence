using API_CDE.Models;

namespace API_CDE.Services
{
    public interface IAccountSurveyRequest
    {
        public IEnumerable<AccountSurveyRequest> List();
        public AccountSurveyRequest Add(int idSurveyRequest, int idAccount);
    }
}
