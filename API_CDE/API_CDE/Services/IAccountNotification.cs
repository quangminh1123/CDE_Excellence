using API_CDE.Models;

namespace API_CDE.Services
{
    public interface IAccountNotification
    {
        public AccountNotification Add(int IdNoti, int IdReceiver);
    }
}
