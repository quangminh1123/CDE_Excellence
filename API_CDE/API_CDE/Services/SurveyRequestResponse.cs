using API_CDE.Data;
using API_CDE.Models;

namespace API_CDE.Services
{
    public class SurveyRequestResponse : ISurveyRequest
    {
        private readonly ApplicationDBContext _context;
        public SurveyRequestResponse(ApplicationDBContext context) => _context = context;
        public SurveyRequest Add(string title, int idCreator, int idSurveyArticle, DateTime startDate, DateTime endDate)
        {
            try
            {
                if (startDate > endDate)
                    return null;
                var suRe = new SurveyRequest()
                {
                    Title = title,
                    IdCreator = idCreator,
                    IdSuAr = idSurveyArticle,
                    StartDate = startDate,
                    EndDate = endDate
                };
                _context.SurveyRequests.Add(suRe);
                _context.SaveChanges();
                return suRe;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public IEnumerable<SurveyRequest> GetByIdReceiver(int idReceiver)
        {
            var idSuveyArticleList = _context.AccountSurveyRequests.Where(x => x.IdAcc == idReceiver).Select(x => x.IdSuRe);
            return _context.SurveyRequests.Where(x => idSuveyArticleList.Contains(x.IdSuRe));
        }

        public SurveyRequest GetSurveyRequest(int id)
        {
            var suRe = _context.SurveyRequests.Find(id);
            if (suRe == null)
                return null;
            return suRe;
        }

        public IEnumerable<SurveyRequest> SurveyRequestList()
        {
           return _context.SurveyRequests;
        }
    }
}
