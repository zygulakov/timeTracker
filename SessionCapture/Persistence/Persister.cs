using SessionCapture.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace SessionCapture.Persistence
{
    public class Persister
    {
        private BinaryFormatter bf;
        private Stream stream;
        private string filePath;
        public Persister(string filePath)
        {
            bf = new BinaryFormatter();
            this.filePath = filePath;
        }
        public void Save(List<Session> sessions)
        {
            stream = File.OpenWrite(filePath);
            bf.Serialize(stream, sessions);
            stream.Close();

        }
        public List<Session> Load()
        {
            if (!File.Exists(filePath))
                return new List<Session>();
            stream =File.OpenRead(filePath);
            List<Session> sessions = (List<Session>)bf.Deserialize(stream);
            stream.Close();
            return sessions;


        }


    }
}
