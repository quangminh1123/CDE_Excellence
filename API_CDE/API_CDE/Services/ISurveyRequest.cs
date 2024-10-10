using API_CDE.Models;

namespace API_CDE.Services
{
    public interface ISurveyRequest
    {
        public IEnumerable<SurveyRequest> SurveyRequestList();
        public IEnumerable<SurveyRequest> GetByIdReceiver(int idReceiver);  
        public SurveyRequest GetSurveyRequest(int id);
        public SurveyRequest Add(string title, int idCreator, int idSurveyArticle, DateTime startDate, DateTime endDate);
    }
}
