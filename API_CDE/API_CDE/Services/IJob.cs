using API_CDE.Models;

namespace API_CDE.Services
{
    public interface IJob
    {
        public Job GetJob(int id);
        public IEnumerable<Job> GetJobByIdCreator(int idCreator);
        public IEnumerable<Job> GetJobByIdImplementer(int idImplementer);
        public Job Add(string title, string Descibe, DateTime startDate, DateTime endDate, int idViSc, int idImplementer, int idCreator);
        public Job UpdateStatus(int id, string status);
    }
}
