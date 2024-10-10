using API_CDE.Models;
using Microsoft.EntityFrameworkCore;

namespace API_CDE.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //quan hệ khóa ngoại Account
            modelBuilder.Entity<Account>()
               .HasOne(a => a.Position)
               .WithMany(d => d.accounts)
               .HasForeignKey(d => d.IdPosition)
               .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Account>()
              .HasOne(a => a.Area)
              .WithMany(d => d.accounts)
              .HasForeignKey(d => d.IdArea)
              .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Account>()
             .HasOne(a => a.Distributor)
             .WithMany(d => d.accounts)
             .HasForeignKey(d => d.IdDis)
             .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Account>()
             .HasOne(a => a.AccManager)
             .WithMany(d => d.managedAccounts)
             .HasForeignKey(d => d.IdManager)
             .OnDelete(DeleteBehavior.NoAction);

            //Quan hệ khóa ngoại AccountAnswer
            modelBuilder.Entity<AccountAnswer>()
             .HasOne(a => a.Question)
             .WithMany(d => d.accountAnswers)
             .HasForeignKey(d => d.IdQuestion)
             .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<AccountAnswer>()
             .HasOne(a => a.Answer)
             .WithMany(d => d.accountAnswers)
             .HasForeignKey(d => d.IdAnswer)
             .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<AccountAnswer>()
             .HasOne(a => a.Account)
             .WithMany(d => d.accountAnswers)
             .HasForeignKey(d => d.IdAcc)
             .OnDelete(DeleteBehavior.NoAction);

            //Quan hệ khóa ngoại AccountNotification
            modelBuilder.Entity<AccountNotification>()
                .HasOne(a => a.Notification)
                .WithMany(d => d.accountNotifications)
                .HasForeignKey(d => d.IdNoti)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<AccountNotification>()
              .HasOne(a => a.Account)
              .WithMany(d => d.accountNotifications)
              .HasForeignKey(d => d.IdReceiver)
              .OnDelete(DeleteBehavior.NoAction);

            //Quan hệ khóa ngoại AccountSurveyRequest
            modelBuilder.Entity<AccountSurveyRequest>()
              .HasOne(a => a.Account)
              .WithMany(d => d.accountSurveyRequests)
              .HasForeignKey(d => d.IdAcc)
              .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<AccountSurveyRequest>()
             .HasOne(a => a.SurveyRequest)
             .WithMany(d => d.accountSurveyRequests)
             .HasForeignKey(d => d.IdSuRe)
             .OnDelete(DeleteBehavior.NoAction);

            //Quan hệ khóa ngoại Answer
            modelBuilder.Entity<Answer>()
             .HasOne(a => a.Question)
             .WithMany(d => d.answers)
             .HasForeignKey(d => d.IdQuestion)
             .OnDelete(DeleteBehavior.NoAction);

            //Quan hệ khóa ngoại Article
            modelBuilder.Entity<Article>()
             .HasOne(a => a.Account)
             .WithMany(d => d.articles)
             .HasForeignKey(d => d.IdCreator)
             .OnDelete(DeleteBehavior.NoAction);

            //Quan hệ khóa ngoại ArticleImage
            modelBuilder.Entity<ArticleImage>()
             .HasOne(a => a.Account)
             .WithMany(d => d.articleImages)
             .HasForeignKey(d => d.IdCreator)
             .OnDelete(DeleteBehavior.NoAction);

            //Quan hệ khóa ngoại DateVist
            modelBuilder.Entity<DateVisit>()
             .HasOne(a => a.VisitSchedule)
             .WithMany(d => d.dateVisits)
             .HasForeignKey(d => d.IdViSc)
             .OnDelete(DeleteBehavior.NoAction);

            //Quan hệ khóa ngoại Distributor
            modelBuilder.Entity<Distributor>()
             .HasOne(a => a.Account)
             .WithMany(d => d.ManagedDistributors)
             .HasForeignKey(d => d.IdManager)
             .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Distributor>()
            .HasOne(a => a.Area)
            .WithMany(d => d.distributors)
            .HasForeignKey(d => d.IdArea)
            .OnDelete(DeleteBehavior.NoAction);

            //Quan hệ khóa ngoại Job
            modelBuilder.Entity<Job>()
                .HasOne(a => a.Implementer)
                .WithMany(d => d.jobImplementers)
                .HasForeignKey(d => d.IdImplementer)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Job>()
               .HasOne(a => a.Creator)
               .WithMany(d => d.jobCreators)
               .HasForeignKey(d => d.IdCreator)
               .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Job>()
               .HasOne(a => a.VisitSchedule)
               .WithMany(d => d.jobs)
               .HasForeignKey(d => d.IdViSc)
               .OnDelete(DeleteBehavior.NoAction);

            //quan hệ khóa ngoại JobImage
            modelBuilder.Entity<JobImage>()
               .HasOne(a => a.Job)
               .WithMany(d => d.JobImages)
               .HasForeignKey(d => d.IdJob)
               .OnDelete(DeleteBehavior.NoAction);

            //quan hệ khóa ngoại Notification
            modelBuilder.Entity<Notification>()
               .HasOne(a => a.Account)
               .WithMany(d => d.notifications)
               .HasForeignKey(d => d.IdCreator)
               .OnDelete(DeleteBehavior.NoAction);

            //Quan hệ khóa ngoại Position
            modelBuilder.Entity<Position>()
               .HasOne(a => a.positionGroup)
               .WithMany(d => d.positions)
               .HasForeignKey(d => d.IdPoGr)
               .OnDelete(DeleteBehavior.NoAction);

            //quan hệ khóa ngoại Question
            modelBuilder.Entity<Question>()
               .HasOne(a => a.SurveyArticle)
               .WithMany(d => d.questions)
               .HasForeignKey(d => d.IdSuAr)
               .OnDelete(DeleteBehavior.NoAction);

            //quan hệ khóa ngoại SurveyArticle
            modelBuilder.Entity<SurveyArticle>()
               .HasOne(a => a.Account)
               .WithMany(d => d.surveyArticles)
               .HasForeignKey(d => d.IdCreator)
               .OnDelete(DeleteBehavior.NoAction);

            //quan hệ khóa ngoại SurveyRequest
            modelBuilder.Entity<SurveyRequest>()
               .HasOne(a => a.Account)
               .WithMany(d => d.surveyRequests)
               .HasForeignKey(d => d.IdCreator)
               .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<SurveyRequest>()
              .HasOne(a => a.SurveyArticle)
              .WithMany(d => d.surveyRequests)
              .HasForeignKey(d => d.IdSuAr)
              .OnDelete(DeleteBehavior.NoAction);

            //quan hệ khóa ngoại Visitor
            modelBuilder.Entity<Visitor>()
              .HasOne(a => a.Account)
              .WithMany(d => d.visitors)
              .HasForeignKey(d => d.IdAcc)
              .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Visitor>()
             .HasOne(a => a.VisitSchedule)
             .WithMany(d => d.visitors)
             .HasForeignKey(d => d.IdViSc)
             .OnDelete(DeleteBehavior.NoAction);

            //quan hệ khóa ngoại VisitSchedule
            modelBuilder.Entity<VisitSchedule>()
             .HasOne(a => a.Account)
             .WithMany(d => d.visitSchedules)
             .HasForeignKey(d => d.IdCreator)
             .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<VisitSchedule>()
             .HasOne(a => a.Distributor)
             .WithMany(d => d.visitSchedules)
             .HasForeignKey(d => d.IdDistributor)
             .OnDelete(DeleteBehavior.NoAction);

        }

        public DbSet<PositionGroup> PositionGroups { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountAnswer> AccountAnswers { get; set; }
        public DbSet<AccountNotification> AccountNotifications { get; set; }
        public DbSet<AccountSurveyRequest> AccountSurveyRequests { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleImage> ArticleImages { get; set; }
        public DbSet<DateVisit> DateVisits { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobImage> JobImages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<SurveyArticle> SurveyArticles { get; set; }
        public DbSet<SurveyRequest> SurveyRequests { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<VisitSchedule> VisitSchedules { get; set; }
    }
}
