using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Economic
{
	public static class FileReader
	{
		public static string ReadFile(string filepath)
		{
			string content = null;

			/*new Thread(() =>
			{
				
			}).Start();*/
			if (!File.Exists(filepath))
			{
				content = "File not found";
			}
			else
			{
				content = File.ReadAllText(filepath);
			}

			return content;
		}
	}
}
