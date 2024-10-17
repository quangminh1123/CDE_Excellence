using API_CDE.Data;
using API_CDE.Models;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Unicode;

namespace API_CDE.Services
{
    public class VisitScheduleResponse : IVisitSchedule
    {
        private readonly ApplicationDBContext _context;
        public VisitScheduleResponse(ApplicationDBContext context) => _context = context;
        public VisitSchedule Add(string session, string purpose, int idDistributor, int idCreator)
        {
            try
            {
                var viSc = new VisitSchedule()
                {
                    Session = session,
                    Purpose = purpose,
                    IdDistributor = idDistributor,
                    IdCreator = idCreator,
                    Status = "Mới"
                };
                _context.VisitSchedules.Add(viSc);
                _context.SaveChanges();
                return viSc;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public VisitSchedule GetVisitSchedule(int id)
        {
            var viSc = _context.VisitSchedules.Find(id);
            if (viSc == null)
                return null;
            return viSc;
        }

        public string Search(DateTime startDate, DateTime endDate, string status, int idDistributor)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                    ReferenceHandler = ReferenceHandler.Preserve,
                    WriteIndented = true
                };
                var viSC = _context.VisitSchedules.Include(x => x.dateVisits).Include(x=>x.visitors)
                    .Where(x => x.dateVisits.Any(d => d.Date >= startDate && d.Date <= endDate))
                    .Where(x => x.Status.ToLower().Contains(status.ToLower())).Where(x => x.IdDistributor == idDistributor);
                var json = JsonSerializer.Serialize(viSC, options);
                return json;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public IEnumerable<VisitSchedule> VisitScheduleList()
        {
            return _context.VisitSchedules;
        }
    }
}
