using API_CDE.Data;
using API_CDE.Models;
using SQLitePCL;

namespace API_CDE.Services
{
    public class ArticleImageResponse : IArticleImage
    {
        private readonly ApplicationDBContext _context;
        public ArticleImageResponse(ApplicationDBContext context) => _context = context;

        public ArticleImage Add(IFormFile image, int idCreator)
        {
            try
            {
                var imagePath = SaveImage(image);
                var arIm = new ArticleImage()
                {

                    Image = $"/Images/ArticleImages/{imagePath}",
                    IdCreator = idCreator
                };
                _context.ArticleImages.Add(arIm);
                _context.SaveChanges();
                return arIm;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public IEnumerable<ArticleImage> ArticleImageList()
        {
            return _context.ArticleImages;
        }

        public string Delete(int id)
        {
            try
            {
                var arIm = _context.ArticleImages.Find(id);
                if (arIm == null)
                    return "Not found";
                _context.ArticleImages.Remove(arIm);
                var imgOld = Path.Combine(Directory.GetCurrentDirectory(), "Images", "ArticleImages", Path.GetFileName(arIm.Image));
                if (File.Exists(imgOld))
                {
                    File.Delete(imgOld);
                }
                _context.SaveChanges();
                return "Delete Success";
            }
            catch (Exception)
            {

                return "Cannot remove";
            }
        }

        private string SaveImage(IFormFile imageFile)
        {
            if (imageFile == null)
                return null;
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "Images/ArticleImages");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            var filePath = Path.Combine(uploadPath, imageFile.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyToAsync(fileStream);
            }
            return imageFile.FileName;
        }
    }
}
