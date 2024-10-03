using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_CDE.Models
{
    public class AccountNotification
    {
        [Key]
        public int IdAcNo { get; set; }

        public int IdNoti {  get; set; }

        public int IdReceiver { get; set; }

        public Notification? Notification { get; set; }
        public Account? Account { get; set; }
    }
}
