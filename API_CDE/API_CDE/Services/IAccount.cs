using API_CDE.Models;

namespace API_CDE.Services
{
    public interface IAccount
    {
        public string AccountList();
        public Account GetUser(int id);
        public Account AddUser(string fullName, string email, int? idPosition, string status);
        public Account UpdateUser(int id, string fullName, string email, int? idPosition, string status);
        public Account UpdatePersonalAccount(int id, string fullName, string phone, string address);
        public Account AddSale(string fullName, string email, int idPosition, int idManager, string status);
        public Account UpdateSale(int id, string fullName, string email, int idPosition, int idManager, int? idDistributor, string status);
        public string Delete(int id);
        public Account AddSubordinate(int idAccount, int idManager);
        public Account DeleteSubordinate(int idAccount);
    }
}
