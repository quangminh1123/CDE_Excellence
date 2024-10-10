using API_CDE.Data;
using API_CDE.Models;
using API_CDE.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Please enter 'Bearer' [space] and then your token"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddDbContext<ApplicationDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));

//đăng ký service
builder.Services.AddScoped<IAccount, AccountResponse>();
builder.Services.AddScoped<IArea, AreaResponse>();
builder.Services.AddScoped<IPositionGroup, PositionGroupResponse>();
builder.Services.AddScoped<IPosition, PositionResponse>();
builder.Services.AddScoped<IDistributor, DistributorResponse>();
builder.Services.AddScoped<ISurveyArticle, SurveyArticleResponse>();
builder.Services.AddScoped<IQuestion, QuestionResponse>();
builder.Services.AddScoped<IAnswer, AnswerResponse>();
builder.Services.AddScoped<IAccountAnswer, AccountAnswerResponse>();
builder.Services.AddScoped<INotification, NotificationResponse>();
builder.Services.AddScoped<IAccountNotification, AccountNotificationResponse>();
builder.Services.AddScoped<ISurveyRequest, SurveyRequestResponse>();
builder.Services.AddScoped<IAccountSurveyRequest, AccountSurveyRequestResponse>();
builder.Services.AddScoped<IArticle, ArticleResponse>();
builder.Services.AddScoped<IArticleImage, ArticleImageResponse>();
builder.Services.AddScoped<IVisitSchedule, VisitScheduleResponse>();
builder.Services.AddScoped<IDateVisit, DateVisitResponse>();
builder.Services.AddScoped<IVisitor, VisitResponse>();
builder.Services.AddScoped<IJob, JobResponse>();
builder.Services.AddScoped<IJobImage, JobImageResponse>();
builder.Services.AddScoped<ISystemSecurity, SystemSecurityResponse>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
