using API_CDE.Data;
using API_CDE.Models;

namespace API_CDE.Services
{
    public class VisitResponse : IVisitor
    {
        private readonly ApplicationDBContext _context;
        public VisitResponse(ApplicationDBContext context) => _context = context;

        public Visitor Add(int idAcc, int idViSc)
        {
            try
            {
                var visitor = new Visitor()
                {
                    IdAcc = idAcc,
                    IdViSc = idViSc
                };
                _context.Visitors.Add(visitor);
                _context.SaveChanges();
                return visitor;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public IEnumerable<Visitor> GetVisitorByIdViSc(int idViSc)
        {
            return _context.Visitors.Where(x => x.IdViSc == idViSc);
        }
    }
}
