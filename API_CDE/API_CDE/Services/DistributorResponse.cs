using API_CDE.Data;
using API_CDE.Models;
using System.Text.RegularExpressions;

namespace API_CDE.Services
{
    public class DistributorResponse : IDistributor
    {
        private readonly ApplicationDBContext _context;
        public DistributorResponse(ApplicationDBContext context) => _context = context;

        public Distributor AddDistributor(string name, string address, string? phone, int? idArea, int? idManager, string status)
        {
            try
            {
                if (!IsValidPhone(phone))
                    return null;
                var distributor = new Distributor()
                {
                    Name = name,
                    Address = address,
                    Phone = phone,
                    IdArea = idArea,
                    IdManager = idManager,
                    Status = status
                };
                _context.Distributors.Add(distributor);
                _context.SaveChanges();
                return distributor;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public string DeleteDistributor(int id)
        {
            try
            {
                var distributor = _context.Distributors.Find(id);
                if (distributor == null)
                    return "Distributor not found";
                _context.Distributors.Remove(distributor);
                _context.SaveChanges();
                return "Delete Success";
            }
            catch (Exception)
            {

                return "Cannot remove";
            }
        }

        public IEnumerable<Distributor> DistributorList()
        {
            return _context.Distributors;
        }

        public Distributor GetDistributor(int id)
        {
            var distributor = _context.Distributors.Find(id);
            if (distributor == null)
                return null;
            return distributor;
        }

        public Distributor UpdateDistributor(int id, string name, string address, string phone, int? idArea, int? idManager, string status)
        {
            try
            {
                var distributor = _context.Distributors.Find(id);
                if (distributor == null)
                    return null;
                if (!IsValidPhone(phone))
                    return null;
                distributor.Name = name;
                distributor.Address = address;
                distributor.Phone = phone;
                distributor.IdArea = idArea;
                distributor.IdManager = idManager;
                distributor.Status = status;
                _context.SaveChanges();
                return distributor;
            }
            catch (Exception)
            {

                return null;
            }
        }
        private bool IsValidPhone(string phone)
        {
            var regex = new Regex(@"^(03|05|07|08|09)[0-9]{8}$");
            return regex.IsMatch(phone);
        }
    }
}
