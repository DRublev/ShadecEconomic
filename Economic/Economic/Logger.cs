using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Economic
{
	public class Logger
	{
		readonly static string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		private static string logFilepath
		{
			get
			{
				string filename = "logs.txt";
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

		public void Log(string message)
		{

		}
	}
}
