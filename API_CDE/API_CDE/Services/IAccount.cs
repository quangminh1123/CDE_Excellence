using API_CDE.Models;

namespace API_CDE.Services
{
    public interface IAccount
    {
        public IEnumerable<Account> UserList();
        public Account AddUser(string fullName, string email, int? idPosition, string status);
        public Account UpdateUser(int id, string fullName, string email, int? idPosition, string status);
    }
}
