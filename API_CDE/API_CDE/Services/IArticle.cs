using API_CDE.Models;

namespace API_CDE.Services
{
    public interface IArticle
    {
        public IEnumerable<Article> ArticleList();
        public Article GetArticle(int id);
        public Article Add(string title, string descibe, string path, IFormFile image, int idCreator);
        public Article UpdateAriticle(int id, string title, string descibe, string path, IFormFile image);
        public Article UpdateStatusAr(int id, string Status);
        public string Delete(int id);
    }
}
