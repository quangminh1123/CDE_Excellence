using API_CDE.Data;
using API_CDE.Models;

namespace API_CDE.Services
{
    public class JobImageResponse : IJobImage
    {
        private readonly ApplicationDBContext _context;
        public JobImageResponse(ApplicationDBContext context) => _context = context;

        public JobImage Add(IFormFile image, string describe, int idJob)
        {
            try
            {
                var img = new JobImage()
                {
                    Image = SaveImage(image),
                    Descibe = describe,
                    IdJob = idJob
                };
                _context.JobImages.Add(img);
                _context.SaveChanges();
                return img;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public IEnumerable<JobImage> GetImageByIdJob(int idJob)
        {
            return _context.JobImages.Where(x => x.IdJob == idJob);
        }

        private string SaveImage(IFormFile imageFile)
        {
            if (imageFile == null)
                return null;
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "Images/JobImages");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            var filePath = Path.Combine(uploadPath, imageFile.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyToAsync(fileStream);
            }
            return $"Images/JobImages/{imageFile.FileName}";
        }
    }
}
