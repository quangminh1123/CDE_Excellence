using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_CDE.Models
{
    public class Account
    {
        [Key]
        public int IdAcc { get; set; }

        [Required, MaxLength(150)]
        public string FullName { get; set; }

        [Required, Column(TypeName = "varchar(100)"), EmailAddress]
        public string Email { get; set; }

        [Required, Column(TypeName = "varchar(40)"), RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
        ErrorMessage = "Password must be at least 8 characters including lower case, upper case, digital numbers and special characters")]
        public string Password { get; set; }

        [Column(TypeName = "varchar(12)")]
        public string? Phone { get; set; }

        [Required, MaxLength(100)]
        public string Role { get; set; }

        [Required, MaxLength(100)]
        public string Status { get; set; }

        public int? IdPosition { get; set; }

        public int? IdArea { get; set; }

        public int? IdDis { get; set; }

        public int? IdManager { get; set; }

        public Position? Position { get; set; }
        public Area? Area { get; set; }
        public Distributor? Distributor { get; set; }
        public Account? AccManager { get; set; }
        public ICollection<Account>? managedAccounts { get; set; }
        public ICollection<AccountAnswer>? accountAnswers { get; set; }
        public ICollection<AccountNotification>? accountNotifications { get; set; }
        public ICollection<AccountSurveyRequest>? accountSurveyRequests { get; set; }
        public ICollection<Article>? articles { get; set; }
        public ICollection<ArticleImage>? articleImages { get; set; }
        public ICollection<Distributor>? ManagedDistributors { get; set; }
        public ICollection<Job>? jobImplementers { get; set; }
        public ICollection<Job>? jobCreators { get; set; }
        public ICollection<Notification>? notifications { get; set; }
        public ICollection<SurveyArticle>? surveyArticles { get; set; }
        public ICollection<SurveyRequest>? surveyRequests {  get; set; } 
        public ICollection<Visitor>? visitors {  get; set; } 
        public ICollection<VisitSchedule>? visitSchedules { get; set; }
    }
}
