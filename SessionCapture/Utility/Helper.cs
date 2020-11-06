using SessionCapture.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SessionCapture.Utility
{
    public class Helper
    {

        public void Print(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public void Print(List<Session> list)
        {
            list.ForEach(s => Print(s.ToString()));
        }
        public string[] ParseArgs(string arg, Command command)
        {
            string[] splitted = arg.Split(' ');
            //REMOVE => -arg [id] [id] [id]
            return splitted.Length > 1 ? splitted[1..] : new string[0];

        }
    }
}
