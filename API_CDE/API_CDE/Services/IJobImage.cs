using API_CDE.Models;

namespace API_CDE.Services
{
    public interface IJobImage
    {
        public IEnumerable<JobImage> GetImageByIdJob(int idJob);
        public JobImage Add(IFormFile image, string describe, int idJob);
    }
}
