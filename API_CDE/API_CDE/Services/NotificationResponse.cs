using API_CDE.Data;
using API_CDE.Models;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Unicode;

namespace API_CDE.Services
{
    public class NotificationResponse : INotification
    {
        private readonly ApplicationDBContext _context;
        public NotificationResponse(ApplicationDBContext context) => _context = context;

        public Notification AddNotification(string title, string content, int idCreator, string status)
        {
            var notification = new Notification
            {
                Title = title,
                Content = content,
                IdCreator = idCreator,
                Status = status
            };
            _context.Notifications.Add(notification);
            _context.SaveChanges();
            return notification;
        }

        public string GetByIdAccount(int idCreator)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };
            var noti = _context.Notifications.Where(x => x.IdCreator == idCreator).ToList();
            var json = JsonSerializer.Serialize(noti, options);
            return json;
        }

        public Notification GetNotification(int id)
        {
            var noti = _context.Notifications.Find(id);
            if (noti == null)
                return null;
            return noti;
        }
    }
}
