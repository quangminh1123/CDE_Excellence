﻿using API_CDE.Models;

namespace API_CDE.Services
{
    public interface INotification
    {
        public IEnumerable<Notification> NotificationList();
        public IEnumerable<Notification> GetByIdReceiver(int idReceiver);
        public string GetByIdAccount(int iCreator);
        public Notification GetNotification(int id);
        public Notification AddNotification(string title, string content, int idCreator, string status);
        public IEnumerable<Notification> SearchNotification(string keyword);
    }
}
