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
	public class CsvDataWorker : ISheetDataWorker
	{
		private string assemblyPath = string.Empty;
		private string csvPath = string.Empty;

		public CsvDataWorker()
		{
			assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			csvPath = Path.Combine(assemblyPath, "shadec.csv");
		}

		~CsvDataWorker()
		{

		}

		public List<List<object>> ReadData(string sheetname = "test", string range = "A:D")
		{
			List<List<object>> info = new List<List<object>>();

			if(sheetname == "prices")
			{
				csvPath = Path.Combine(assemblyPath, "shadec-prices.csv");
			}

			try
			{
				using (TextFieldParser parser = new TextFieldParser(csvPath))
				{
					parser.TextFieldType = FieldType.Delimited;
					parser.SetDelimiters(",");

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

		public void WriteData(List<List<object>> data,
			string sheetName = "test", string range = "A:D")
		{

		}

		public void UpdateData(List<object> data,
			string sheetName = "test", string range = "A:D")
		{

		}

		public void DeleteData(string sheetName = "test", string range = "A:D")
		{

		}
	}
}
