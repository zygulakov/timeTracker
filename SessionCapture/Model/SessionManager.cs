using SessionCapture.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SessionCapture.Model
{
    class SessionManager
    {
        private Persister persister;
        private List<Session> sessionsList;
        private static int lastId;
        public SessionManager()
        {
            sessionsList = new List<Session>();
            persister = new Persister("SessionTrackerData");
            loadData();
            lastId = sessionsList.Count>0 ? sessionsList.Last().Id : 0;
        }
        public void StartNewSession(string comment)
        {
            Session session = new Session(++lastId);
            session.StartTime = DateTime.Now;
            session.EndTime = DateTime.MinValue;
            session.Comment = comment;
            sessionsList.Add(session);
            updateData();
        }
        public void EndSession(int id)
        {
            if (!sessionsList.Exists(s => s.Id == id))
                throw new ArgumentOutOfRangeException($"couldn't find session with given id:{id}");
            if (sessionsList.Find(s => s.Id == id).EndTime != DateTime.MinValue)
                throw new Exception($"this session {id} already ended");

            Session session = sessionsList.Find(s => s.Id == id);
            session.EndTime = DateTime.Now; ;
            updateData();

        }
        public void EndSession()
        {
            if (sessionsList.Count < 1)
                throw new Exception("session list is empty");
            if (sessionsList.Last().EndTime != DateTime.MinValue)
                throw new Exception($"this session {lastId} already ended");

            sessionsList.Last().EndTime = DateTime.Now;
            updateData();

        }
        public void Remove(int id)
        {
            if (!sessionsList.Exists(s => s.Id == id))
                throw new ArgumentOutOfRangeException($"couldn't find session with given id:{id}");
            sessionsList.RemoveAll(s => s.Id == id);
            updateData();

        }

        public List<Session> List()
        {
            return sessionsList.AsReadOnly().ToList();
        }
        private void updateData()
        {
            persister.Save(sessionsList);
        }
        private void loadData()
        {
            sessionsList = persister.Load();
        }
    }
}
