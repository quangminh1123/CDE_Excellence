using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_CDE.Models
{
    public class Notification
    {
        [Key]
        public int IdNoti { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [Required, MaxLength(100)]
        public string Status { get; set; }

        public int IdCreator { get; set; }

        public Account? Account { get; set; }
        public ICollection<AccountNotification>? accountNotifications { get; set; }
    }
}
