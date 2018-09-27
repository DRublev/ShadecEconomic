using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Economic
{
	public class CsvDataHandler : IDataHandler
	{
		private string assemblyPath = string.Empty;
		private string csvPath = string.Empty;
		private string separator = "|";

		public CsvDataHandler()
		{
			assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			csvPath = Path.Combine(assemblyPath, "shadec.csv");
		}

		~CsvDataHandler()
		{

		}

		public List<List<object>> ReadData(string sheetName = "test")
		{
			List<List<object>> info = new List<List<object>>();

			if(sheetName == "prices")
			{
				csvPath = Path.Combine(assemblyPath, "shadec-prices.csv");
				separator = ";";
			}

			try
			{
				using (TextFieldParser parser = new TextFieldParser(csvPath))
				{
					parser.TextFieldType = FieldType.Delimited;
					parser.SetDelimiters(separator);

					while (!parser.EndOfData)
					{
						List<object> row = new List<object>();

						foreach (object field in parser.ReadFields())
						{
							row.Add(field);
						}

						info.Add(row);
					}
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine($"File not found {csvPath} {ex.Message}");
			}

			return info;
		}

		private List<string> PrepareData(List<List<object>> data)
		{
			List<string> allLines = new List<string>();

			foreach (List<object> row in data)
			{
				string dataStr = string.Empty;

				for (int i = 0; i < row.Count; i++)
				{
					string line = $"{row[i].ToString()}";

					if (i != row.Count - 1)
					{
						line += $"{separator}";
					}

					dataStr += line;
				}

				allLines.Add(dataStr);
			}

			return allLines;
		}

		public void WriteData(List<List<object>> data, string sheetName = "test")
		{
			if (sheetName == "prices")
			{
				csvPath = Path.Combine(assemblyPath, "shadec-prices.csv");
				separator = ";";
			}
			List<string> allLines = PrepareData(data);

			File.AppendAllLines(csvPath, allLines);
		}

		public void UpdateData(List<object> dataNew, List<object> dataOld, string sheetName = "test")
		{
			List<List<object>> data = ReadData(sheetName);

			int oldDataIndex = data.FindIndex(el 
				=> el[0].ToString() == dataOld[0].ToString());

			try
			{
				if(oldDataIndex != -1)
				{
					data[oldDataIndex] = dataNew;
					File.WriteAllLines(csvPath, PrepareData(data));
				}
				else
				{
					throw new Exception(oldDataIndex.ToString());
				}				
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public void DeleteData(string sheetName = "test", int row = -1)
		{
			if(row == -1)
			{
				return; //Error - tryiong to delete not existing data
			}

			List<List<object>> data = ReadData(sheetName);

			data.RemoveAt(row);
			WriteData(data);
		}
	}
}
