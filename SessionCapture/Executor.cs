using SessionCapture.Model;
using SessionCapture.Utility;
using System;
using System.Collections.Generic;

namespace SessionCapture
{
	public class Executor
	{
		private SessionManager manager;
		private Helper helper;
		public Executor()
		{
			manager = new SessionManager();
			helper = new Helper();
		}
		public void Run(string arguments, Command command)
		{   //return argumetns of main argument
			string[] ids = helper.ParseArgs(arguments, command);
			//Remove
			if (command.Equals(Command.REMOVE_SESSION))
			{
				if (ids.Length > 0)
				{
					foreach (string strId in ids)
					{
						int id = int.Parse(strId);
						manager.Remove(id);

					}
					helper.Info($"session(s) deleted");
					helper.Print(manager.List());
				}
			}
			//End
			if (command.Equals(Command.END_SESSION))
			{
				if (ids.Length > 0)
				{
					foreach (string strId in ids)
					{
						int id = int.Parse(strId);
						manager.EndSession(id);
					}
				}
				else
					manager.EndSession();
				helper.Info($"session(s) ended");
				helper.Print(manager.List());
			}
			//List
			if (command.Equals(Command.LIST_SESSION))
			{
				List<Session> sessionList = manager.List();
				helper.Print(sessionList);
			}
			//New
			if (command.Equals(Command.NEW_SESSION))
			{
				string comment = string.Join(' ', ids);
				manager.StartNewSession(comment);

				helper.Info($"session created");
				helper.Print(manager.List());
			}
			//Manual
			if (command.Equals(Command.MANUAL))
			{

				helper.Info("read: README.md in github");
			}
			//CALCULATE
			if (command.Equals(Command.CALCULATE))
			{
				TimeSpan total = TimeSpan.Zero;

				foreach (string strId in ids)
				{
					int id = int.Parse(strId);
					Session ses = manager.List().Find(s => s.Id == id);
					if (ses != null)
					{
						if (ses.EndTime == DateTime.MinValue)
							total += DateTime.Now - ses.StartTime;
						else
							total += ses.EndTime - ses.StartTime;
						helper.Print(ses.ToString());
					}
					else throw new Exception("cant find specified id");
				}
				helper.Print("----------------------------");
				helper.Print($"Total: {total.TotalMinutes} mins  =  {total.TotalHours.ToString("N2")} hours");
			}
		}
	}
}
