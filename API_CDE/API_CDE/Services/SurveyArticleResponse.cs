
using API_CDE.Data;
using API_CDE.Models;

namespace API_CDE.Services
{
    public class SurveyArticleResponse : ISurveyArticle
    {
        private readonly ApplicationDBContext _context;
        public SurveyArticleResponse(ApplicationDBContext context) => _context = context;

        public SurveyArticle AddSuAr(string title, int idCreator, string status)
        {
            var suAr = new SurveyArticle()
            {
                Title = title,
                IdCreator = idCreator,
                Status = status
            };
            _context.SurveyArticles.Add(suAr);
            _context.SaveChanges();
            return suAr;
        }

        public string DeleteSuAr(int id)
        {
            try
            {
                var suAr = _context.SurveyArticles.Find(id);
                if (suAr == null)
                    return "Not found";
                _context.SurveyArticles.Remove(suAr);
                _context.SaveChanges();
                return "Delete Success";
            }
            catch (Exception)
            {
                return "Cannot remove";
            }
        }

        public SurveyArticle GetById(int id)
        {
            var suAr = _context.SurveyArticles.Find(id);
            if (suAr == null)
                return null;
            return suAr;
        }

        public IEnumerable<SurveyArticle> SuArList()
        {
            return _context.SurveyArticles;
        }

        public SurveyArticle UpdateSuAr(int id, string title, string status)
        {
            try
            {
                var suAr = _context.SurveyArticles.Find(id);
                if (suAr == null)
                    return null;
                suAr.Title = title;
                suAr.Status = status;
                _context.SaveChanges();
                return suAr;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
