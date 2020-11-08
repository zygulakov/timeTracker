using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SessionCapture.Model
{
    [Serializable]
    public class Session
    {
        public Session(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public override string ToString()
        {
            string startTime = StartTime != DateTime.MinValue ? StartTime.ToShortTimeString() : "...";
            string endTime = EndTime != DateTime.MinValue ? EndTime.ToShortTimeString() : "...     ";
            return $"Session:[{Id}] | {startTime} - {endTime} | {Comment}";
        }
    }
}
