using API_CDE.Models;

namespace API_CDE.Services
{
    public interface ISurveyArticle
    {
        public IEnumerable<SurveyArticle> SuArList();
        public SurveyArticle GetById(int id);
        public SurveyArticle AddSuAr(string title, int idCreator, string status);
        public SurveyArticle UpdateSuAr(int id,string title, string status);
        public string DeleteSuAr(int id);
    }
}
