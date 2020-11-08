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
            Console.ForegroundColor = ConsoleColor.Green;
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
            for (int i = 0; i < list.Count; i++)
            {
                if (i % 2 == 0)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(list[i]);
            }
            Console.ResetColor();
        }
        public string[] ParseArgs(string arg, Command command)
        {
            string[] splitted = arg.Split(' ');
            //REMOVE => -arg [id] [id] [id]
            return splitted.Length > 1 ? splitted[1..] : new string[0];

        }
    }
}
