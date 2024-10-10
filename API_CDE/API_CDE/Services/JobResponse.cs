using API_CDE.Data;
using API_CDE.Models;

namespace API_CDE.Services
{
    public class JobResponse : IJob
    {
        private readonly ApplicationDBContext _context;
        public JobResponse(ApplicationDBContext context) => _context = context;

        public Job Add(string title, string Descibe, DateTime startDate, DateTime endDate, int idViSc, int idImplementer, int idCreator)
        {
            try
            {
                if (startDate > endDate)
                    return null;
                var job = new Job
                {
                    Title = title,
                    Describe = Descibe,
                    StartDate = startDate,
                    EndDate = endDate,
                    IdViSc = idViSc,
                    IdImplementer = idImplementer,
                    IdCreator = idCreator,
                    Status = "Mới"
                };
                _context.Jobs.Add(job);
                _context.SaveChanges();
                return job;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Job GetJob(int id)
        {
            return _context.Jobs.FirstOrDefault(x => x.IdJob == id);
        }

        public IEnumerable<Job> GetJobByIdCreator(int idCreator)
        {
            return _context.Jobs.Where(x => x.IdCreator == idCreator);
        }

        public IEnumerable<Job> GetJobByIdImplementer(int idImplementer)
        {
            return _context.Jobs.Where(x => x.IdImplementer == idImplementer);
        }

        public Job UpdateStatus(int id, string status)
        {
            var job = _context.Jobs.Find(id);
            if (job == null)
                return null;
            job.Status = status;
            _context.SaveChanges();
            return job;
        }
    }
}
