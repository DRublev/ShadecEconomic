using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Economic
{
	[SuppressMessage("ReSharper", "SuggestVarOrType_BuiltInTypes")]
	public class Logger
	{
		private static readonly string dir = 
			Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		private static string logFilepath
		{
			get
			{
				const string filename = "logs.txt";
				return Path.Combine(dir, filename);
			}
		}
		private static string errorsFilepath
		{
			get
			{
				string filename = "errors.txt";
				return Path.Combine(dir, filename);
			}
		}
		
		public Logger()
		{

		}
		
		private string CurrentDate()
		{
			string current = DateTime.Now.ToShortDateString();
			return current;
		}
		private static string CurrentTime()
		{
			string current = DateTime.Now.ToLongTimeString();
			return current;
		}

		public static void Log(string message, object sender)
		{
			string logInfo = $"{CurrentTime()} : {message} | {sender}";

			Thread thread = new Thread(() =>
			{
				StreamWriter sw = null;
				try
				{
					sw = new StreamWriter(logFilepath, true);
					sw.WriteLineAsync(logInfo);
				}
				catch(Exception ex)
				{
					throw new Exception(ex.Message);
				}
				finally
				{
					sw?.Close();

					GC.Collect();
				}
			});
			thread.Start();

			while (thread.IsAlive) { }

			thread.Abort();
		}
	}
}
