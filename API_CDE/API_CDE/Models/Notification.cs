using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_CDE.Models
{
    public class Notification
    {
        [Key]
        public int IdNoti { get; set; }

        [Required, Column(TypeName = "ntext")]
        public string Title { get; set; }

        [Required, Column(TypeName = "ntext")]
        public string Content { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public int IdCreator { get; set; }

        public Account? Account { get; set; }
        public ICollection<AccountNotification>? accountNotifications { get; set; }
    }
}
