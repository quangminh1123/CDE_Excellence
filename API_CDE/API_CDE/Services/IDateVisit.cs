using API_CDE.Models;

namespace API_CDE.Services
{
    public interface IDateVisit
    {
        public IEnumerable<DateVisit> dateVisitByIdViSc(int idViSc);
        public DateVisit Add(DateTime date, int idViSc);
    }
}
