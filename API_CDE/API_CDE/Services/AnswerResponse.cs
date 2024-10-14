using API_CDE.Data;
using API_CDE.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace API_CDE.Services
{
    public class AnswerResponse : IAnswer
    {
        private readonly ApplicationDBContext _context;
        public AnswerResponse(ApplicationDBContext context) => _context = context;

        public Answer AddAnswer(string content, int idQuestion)
        {
            try
            {
                var answer = new Answer()
                {
                    Content = content,
                    IdQuestion = idQuestion
                };
                _context.Answers.Add(answer);
                _context.SaveChanges();
                return answer;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public string DeleteAnswer(int id)
        {
            try
            {
                var answer = _context.Answers.Find(id);
                if (answer == null)
                    return "Not found";
                _context.Answers.Remove(answer);
                _context.SaveChanges();
                return "Delete Success";
            }
            catch (Exception)
            {

                return "Cannot Remove";
            }
        }

        public IEnumerable<Answer> GetAnsersByIdQuestion(int idQuestion)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                    ReferenceHandler = ReferenceHandler.Preserve,
                    WriteIndented = true
                };
                var answers = _context.Answers.Where(x => x.IdQuestion == idQuestion).ToList();
                var json = JsonSerializer.Serialize(answers, options);
                return answers;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Answer UpdateAnswer(int id, string content)
        {
            try
            {
                var answer = _context.Answers.Find(id);
                if (answer == null)
                    return null;
                answer.Content = content;
                _context.SaveChanges();
                return answer;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
