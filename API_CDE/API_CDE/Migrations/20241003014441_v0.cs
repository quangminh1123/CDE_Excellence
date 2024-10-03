using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_CDE.Migrations
{
    public partial class v0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    IdArea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaCode = table.Column<string>(type: "varchar(30)", nullable: false),
                    AreaName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.IdArea);
                });

            migrationBuilder.CreateTable(
                name: "PositionGroups",
                columns: table => new
                {
                    IdPoGr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionGroups", x => x.IdPoGr);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    IdPos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IdPoGr = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.IdPos);
                    table.ForeignKey(
                        name: "FK_Positions_PositionGroups_IdPoGr",
                        column: x => x.IdPoGr,
                        principalTable: "PositionGroups",
                        principalColumn: "IdPoGr");
                });

            migrationBuilder.CreateTable(
                name: "AccountAnswers",
                columns: table => new
                {
                    IdUsAn = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdQuestion = table.Column<int>(type: "int", nullable: false),
                    IdAnswer = table.Column<int>(type: "int", nullable: false),
                    IdAcc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountAnswers", x => x.IdUsAn);
                });

            migrationBuilder.CreateTable(
                name: "AccountNotifications",
                columns: table => new
                {
                    IdAcNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdNoti = table.Column<int>(type: "int", nullable: false),
                    IdReceiver = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountNotifications", x => x.IdAcNo);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    IdAcc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Password = table.Column<string>(type: "varchar(40)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdPosition = table.Column<int>(type: "int", nullable: true),
                    IdArea = table.Column<int>(type: "int", nullable: true),
                    IdDis = table.Column<int>(type: "int", nullable: true),
                    IdManager = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.IdAcc);
                    table.ForeignKey(
                        name: "FK_Accounts_Accounts_IdManager",
                        column: x => x.IdManager,
                        principalTable: "Accounts",
                        principalColumn: "IdAcc");
                    table.ForeignKey(
                        name: "FK_Accounts_Areas_IdArea",
                        column: x => x.IdArea,
                        principalTable: "Areas",
                        principalColumn: "IdArea");
                    table.ForeignKey(
                        name: "FK_Accounts_Positions_IdPosition",
                        column: x => x.IdPosition,
                        principalTable: "Positions",
                        principalColumn: "IdPos");
                });

            migrationBuilder.CreateTable(
                name: "ArticleImages",
                columns: table => new
                {
                    IdArIm = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdManager = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleImages", x => x.IdArIm);
                    table.ForeignKey(
                        name: "FK_ArticleImages_Accounts_IdManager",
                        column: x => x.IdManager,
                        principalTable: "Accounts",
                        principalColumn: "IdAcc");
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    IdArticle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Describe = table.Column<string>(type: "ntext", nullable: false),
                    PathArticle = table.Column<string>(type: "varchar(120)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCreator = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.IdArticle);
                    table.ForeignKey(
                        name: "FK_Articles_Accounts_IdCreator",
                        column: x => x.IdCreator,
                        principalTable: "Accounts",
                        principalColumn: "IdAcc");
                });

            migrationBuilder.CreateTable(
                name: "Distributors",
                columns: table => new
                {
                    IdDis = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdArea = table.Column<int>(type: "int", nullable: true),
                    IdManager = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distributors", x => x.IdDis);
                    table.ForeignKey(
                        name: "FK_Distributors_Accounts_IdManager",
                        column: x => x.IdManager,
                        principalTable: "Accounts",
                        principalColumn: "IdAcc");
                    table.ForeignKey(
                        name: "FK_Distributors_Areas_IdDis",
                        column: x => x.IdDis,
                        principalTable: "Areas",
                        principalColumn: "IdArea");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    IdNoti = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "ntext", nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: false),
                    IdCreator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.IdNoti);
                    table.ForeignKey(
                        name: "FK_Notifications_Accounts_IdCreator",
                        column: x => x.IdCreator,
                        principalTable: "Accounts",
                        principalColumn: "IdAcc");
                });

            migrationBuilder.CreateTable(
                name: "SurveyArticles",
                columns: table => new
                {
                    IdSuAr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCreator = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyArticles", x => x.IdSuAr);
                    table.ForeignKey(
                        name: "FK_SurveyArticles_Accounts_IdCreator",
                        column: x => x.IdCreator,
                        principalTable: "Accounts",
                        principalColumn: "IdAcc");
                });

            migrationBuilder.CreateTable(
                name: "VisitSchedules",
                columns: table => new
                {
                    IdViSc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Session = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDistributor = table.Column<int>(type: "int", nullable: true),
                    IdCreator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitSchedules", x => x.IdViSc);
                    table.ForeignKey(
                        name: "FK_VisitSchedules_Accounts_IdCreator",
                        column: x => x.IdCreator,
                        principalTable: "Accounts",
                        principalColumn: "IdAcc");
                    table.ForeignKey(
                        name: "FK_VisitSchedules_Distributors_IdDistributor",
                        column: x => x.IdDistributor,
                        principalTable: "Distributors",
                        principalColumn: "IdDis");
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    IdQuestion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "ntext", nullable: false),
                    IsMultipleChoice = table.Column<bool>(type: "bit", nullable: false),
                    IdSuAr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.IdQuestion);
                    table.ForeignKey(
                        name: "FK_Questions_SurveyArticles_IdSuAr",
                        column: x => x.IdSuAr,
                        principalTable: "SurveyArticles",
                        principalColumn: "IdSuAr");
                });

            migrationBuilder.CreateTable(
                name: "SurveyRequests",
                columns: table => new
                {
                    IdSuRe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "ntext", nullable: false),
                    IdCreator = table.Column<int>(type: "int", nullable: false),
                    IdSuAr = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyRequests", x => x.IdSuRe);
                    table.ForeignKey(
                        name: "FK_SurveyRequests_Accounts_IdCreator",
                        column: x => x.IdCreator,
                        principalTable: "Accounts",
                        principalColumn: "IdAcc");
                    table.ForeignKey(
                        name: "FK_SurveyRequests_SurveyArticles_IdSuAr",
                        column: x => x.IdSuAr,
                        principalTable: "SurveyArticles",
                        principalColumn: "IdSuAr");
                });

            migrationBuilder.CreateTable(
                name: "DateVisits",
                columns: table => new
                {
                    IdDaVi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    IdViSc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateVisits", x => x.IdDaVi);
                    table.ForeignKey(
                        name: "FK_DateVisits_VisitSchedules_IdViSc",
                        column: x => x.IdViSc,
                        principalTable: "VisitSchedules",
                        principalColumn: "IdViSc");
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    IdJob = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Describe = table.Column<string>(type: "ntext", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdViSc = table.Column<int>(type: "int", nullable: false),
                    IdImplementer = table.Column<int>(type: "int", nullable: false),
                    IdAnnunciator = table.Column<int>(type: "int", nullable: false),
                    IdCreator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.IdJob);
                    table.ForeignKey(
                        name: "FK_Jobs_Accounts_IdAnnunciator",
                        column: x => x.IdAnnunciator,
                        principalTable: "Accounts",
                        principalColumn: "IdAcc");
                    table.ForeignKey(
                        name: "FK_Jobs_Accounts_IdCreator",
                        column: x => x.IdCreator,
                        principalTable: "Accounts",
                        principalColumn: "IdAcc");
                    table.ForeignKey(
                        name: "FK_Jobs_Accounts_IdImplementer",
                        column: x => x.IdImplementer,
                        principalTable: "Accounts",
                        principalColumn: "IdAcc");
                    table.ForeignKey(
                        name: "FK_Jobs_VisitSchedules_IdViSc",
                        column: x => x.IdViSc,
                        principalTable: "VisitSchedules",
                        principalColumn: "IdViSc");
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAcc = table.Column<int>(type: "int", nullable: false),
                    IdViSc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visitors_Accounts_IdAcc",
                        column: x => x.IdAcc,
                        principalTable: "Accounts",
                        principalColumn: "IdAcc");
                    table.ForeignKey(
                        name: "FK_Visitors_VisitSchedules_IdViSc",
                        column: x => x.IdViSc,
                        principalTable: "VisitSchedules",
                        principalColumn: "IdViSc");
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    IdAnswer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "ntext", nullable: false),
                    IdQuestion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.IdAnswer);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_IdQuestion",
                        column: x => x.IdQuestion,
                        principalTable: "Questions",
                        principalColumn: "IdQuestion");
                });

            migrationBuilder.CreateTable(
                name: "AccountSurveyRequests",
                columns: table => new
                {
                    IdAcSu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSuRe = table.Column<int>(type: "int", nullable: false),
                    IdAcc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountSurveyRequests", x => x.IdAcSu);
                    table.ForeignKey(
                        name: "FK_AccountSurveyRequests_Accounts_IdAcc",
                        column: x => x.IdAcc,
                        principalTable: "Accounts",
                        principalColumn: "IdAcc");
                    table.ForeignKey(
                        name: "FK_AccountSurveyRequests_SurveyRequests_IdSuRe",
                        column: x => x.IdSuRe,
                        principalTable: "SurveyRequests",
                        principalColumn: "IdSuRe");
                });

            migrationBuilder.CreateTable(
                name: "JobImages",
                columns: table => new
                {
                    IdJoIm = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descibe = table.Column<string>(type: "ntext", nullable: false),
                    IdJob = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobImages", x => x.IdJoIm);
                    table.ForeignKey(
                        name: "FK_JobImages_Jobs_IdJob",
                        column: x => x.IdJob,
                        principalTable: "Jobs",
                        principalColumn: "IdJob");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountAnswers_IdAcc",
                table: "AccountAnswers",
                column: "IdAcc");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAnswers_IdAnswer",
                table: "AccountAnswers",
                column: "IdAnswer");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAnswers_IdQuestion",
                table: "AccountAnswers",
                column: "IdQuestion");

            migrationBuilder.CreateIndex(
                name: "IX_AccountNotifications_IdNoti",
                table: "AccountNotifications",
                column: "IdNoti");

            migrationBuilder.CreateIndex(
                name: "IX_AccountNotifications_IdReceiver",
                table: "AccountNotifications",
                column: "IdReceiver");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_IdArea",
                table: "Accounts",
                column: "IdArea");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_IdDis",
                table: "Accounts",
                column: "IdDis");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_IdManager",
                table: "Accounts",
                column: "IdManager");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_IdPosition",
                table: "Accounts",
                column: "IdPosition");

            migrationBuilder.CreateIndex(
                name: "IX_AccountSurveyRequests_IdAcc",
                table: "AccountSurveyRequests",
                column: "IdAcc");

            migrationBuilder.CreateIndex(
                name: "IX_AccountSurveyRequests_IdSuRe",
                table: "AccountSurveyRequests",
                column: "IdSuRe");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_IdQuestion",
                table: "Answers",
                column: "IdQuestion");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleImages_IdManager",
                table: "ArticleImages",
                column: "IdManager");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_IdCreator",
                table: "Articles",
                column: "IdCreator");

            migrationBuilder.CreateIndex(
                name: "IX_DateVisits_IdViSc",
                table: "DateVisits",
                column: "IdViSc");

            migrationBuilder.CreateIndex(
                name: "IX_Distributors_IdManager",
                table: "Distributors",
                column: "IdManager");

            migrationBuilder.CreateIndex(
                name: "IX_JobImages_IdJob",
                table: "JobImages",
                column: "IdJob");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_IdAnnunciator",
                table: "Jobs",
                column: "IdAnnunciator");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_IdCreator",
                table: "Jobs",
                column: "IdCreator");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_IdImplementer",
                table: "Jobs",
                column: "IdImplementer");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_IdViSc",
                table: "Jobs",
                column: "IdViSc");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_IdCreator",
                table: "Notifications",
                column: "IdCreator");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_IdPoGr",
                table: "Positions",
                column: "IdPoGr");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_IdSuAr",
                table: "Questions",
                column: "IdSuAr");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyArticles_IdCreator",
                table: "SurveyArticles",
                column: "IdCreator");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyRequests_IdCreator",
                table: "SurveyRequests",
                column: "IdCreator");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyRequests_IdSuAr",
                table: "SurveyRequests",
                column: "IdSuAr");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_IdAcc",
                table: "Visitors",
                column: "IdAcc");

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_IdViSc",
                table: "Visitors",
                column: "IdViSc");

            migrationBuilder.CreateIndex(
                name: "IX_VisitSchedules_IdCreator",
                table: "VisitSchedules",
                column: "IdCreator");

            migrationBuilder.CreateIndex(
                name: "IX_VisitSchedules_IdDistributor",
                table: "VisitSchedules",
                column: "IdDistributor");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountAnswers_Accounts_IdAcc",
                table: "AccountAnswers",
                column: "IdAcc",
                principalTable: "Accounts",
                principalColumn: "IdAcc");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountAnswers_Answers_IdAnswer",
                table: "AccountAnswers",
                column: "IdAnswer",
                principalTable: "Answers",
                principalColumn: "IdAnswer");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountAnswers_Questions_IdQuestion",
                table: "AccountAnswers",
                column: "IdQuestion",
                principalTable: "Questions",
                principalColumn: "IdQuestion");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountNotifications_Accounts_IdReceiver",
                table: "AccountNotifications",
                column: "IdReceiver",
                principalTable: "Accounts",
                principalColumn: "IdAcc");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountNotifications_Notifications_IdNoti",
                table: "AccountNotifications",
                column: "IdNoti",
                principalTable: "Notifications",
                principalColumn: "IdNoti");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Distributors_IdDis",
                table: "Accounts",
                column: "IdDis",
                principalTable: "Distributors",
                principalColumn: "IdDis");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distributors_Accounts_IdManager",
                table: "Distributors");

            migrationBuilder.DropTable(
                name: "AccountAnswers");

            migrationBuilder.DropTable(
                name: "AccountNotifications");

            migrationBuilder.DropTable(
                name: "AccountSurveyRequests");

            migrationBuilder.DropTable(
                name: "ArticleImages");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "DateVisits");

            migrationBuilder.DropTable(
                name: "JobImages");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "SurveyRequests");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "VisitSchedules");

            migrationBuilder.DropTable(
                name: "SurveyArticles");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Distributors");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "PositionGroups");

        }
    }
}
