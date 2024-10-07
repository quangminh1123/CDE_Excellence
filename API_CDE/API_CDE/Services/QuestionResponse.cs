using API_CDE.Data;
using API_CDE.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace API_CDE.Services
{
    public class QuestionResponse : IQuestion
    {
        private readonly ApplicationDBContext _context;
        public QuestionResponse(ApplicationDBContext context) => _context = context;

        public Question AddQuestion(string content, bool isMultipleChoice, int idSuAr)
        {
            try
            {
                var question = new Question()
                {
                    Content = content,
                    IsMultipleChoice = isMultipleChoice,
                    IdSuAr = idSuAr
                };
                _context.Questions.Add(question);
                _context.SaveChanges();
                return question;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public string DeleteQuestion(int id)
        {
            try
            {
                var question = _context.Questions.Include(x => x.answers).FirstOrDefault(x => x.IdQuestion == id);
                if (question == null)
                    return "Not found";
                _context.Answers.RemoveRange(question.answers);
                _context.Questions.Remove(question);
                _context.SaveChanges();
                return "Delete Success";
            }
            catch (Exception)
            {

                return "Cannot remove";
            }
        }

        public string GetQuestion(int id)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };
            var question = _context.Questions.Where(x => x.IdQuestion == id).Include(x => x.answers).FirstOrDefault();
            var json = JsonSerializer.Serialize(question, options);
            if (json == null)
                return null;
            return json;
        }

        public string GetQuestionsByIdSuAr(int idSuAr)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                    ReferenceHandler = ReferenceHandler.Preserve,
                    WriteIndented = true
                };
                var questions = _context.Questions.Where(x => x.IdSuAr == idSuAr).Include(x => x.answers).ToList();
                var json = JsonSerializer.Serialize(questions, options);
                return json;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Question UpdateQuestion(int id, string content, bool isMultipleChoice)
        {
            try
            {
                var question = _context.Questions.Find(id);
                if (question == null)
                    return null;
                question.Content = content;
                question.IsMultipleChoice = isMultipleChoice;
                _context.SaveChanges();
                return question;
            }
            catch (Exception)
            {

                return null;
            }

        }
    }
}
