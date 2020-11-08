using SessionCapture.Utility;
using System;
using System.Runtime.CompilerServices;

namespace SessionCapture
{
    class Program
    {

        static void Main(string[] args)
        {
            if (args.Length < 1)
                Environment.Exit(0);
            Executor executor = new Executor();
            Helper helper = new Helper();

            string mainArg = args[0];
            string line = string.Join(' ', args);
            switch (mainArg)
            {
                case "new":
                    executor.Run(line, Command.NEW_SESSION);
                    break;
                case "end":
                    executor.Run(line, Command.END_SESSION);
                    break;
                case "rm":
                    executor.Run(line, Command.REMOVE_SESSION);
                    break;
                case "ls":
                    executor.Run(line, Command.LIST_SESSION);
                    break;
                case "man":
                    break;
                case "clear":
                    Console.Clear();
                    break;
                default:
                    helper.Info("Unknow command use -man for reference");
                    break;
            }

        }
    }
}
