using API_CDE.Models;

namespace API_CDE.Services
{
    public interface IVisitSchedule
    {
        public IEnumerable<VisitSchedule> VisitScheduleList();
        public VisitSchedule GetVisitSchedule(int id);
        public VisitSchedule Add(string session, string purpose, int idDistributor, int idCreator);
        public string Search(DateTime startDate, DateTime endDate, string status, int idDistributor);
    }
}
