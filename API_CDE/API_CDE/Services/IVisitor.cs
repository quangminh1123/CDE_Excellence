using API_CDE.Models;

namespace API_CDE.Services
{
    public interface IVisitor
    {
        public IEnumerable<Visitor> GetVisitorByIdViSc(int idViSc);
        public Visitor Add(int idAcc, int idViSc);
    }
}
