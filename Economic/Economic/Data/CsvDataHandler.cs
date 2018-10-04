using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Economic.Data
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
		
		public bool isDataExist(List<object> data)
		{
			bool founded = false;



			return founded;
		}

		public List<List<object>> ReadData(DataConfig.Lists sheetName = DataConfig.Lists.Main)
		{
			List<List<object>> info = new List<List<object>>();

			if(sheetName == DataConfig.Lists.Prices)
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

						try
						{
							row.AddRange(
								(parser.ReadFields() ?? 
									throw new CustomException(ErrorCodes.Codes.DataReading))
								.Cast<object>());
						}
						catch(NullReferenceException e)
						{
							throw new CustomException(ErrorCodes.Codes.DataReading);
						}

						info.Add(row);
					}
				}
			}
			catch(Exception ex)
			{
				throw new CustomException(ErrorCodes.Codes.DataFileNotFound);
			}

			return info;
		}

		public void WriteData(List<List<object>> data, 
		                      DataConfig.Lists sheetName = DataConfig.Lists.Main)
		{
			if (sheetName == DataConfig.Lists.Prices)
			{
				csvPath = Path.Combine(assemblyPath, "shadec-prices.csv");
				separator = ";";
			}
			List<string> allLines = PrepareData(data);

			try
			{
				File.AppendAllLines(csvPath, allLines);
			}
			catch(FileNotFoundException e)
			{
				throw new CustomException(ErrorCodes.Codes.DataFileNotFound);
			}
			catch(Exception)
			{
				throw new CustomException(ErrorCodes.Codes.DataWriting);
			}
		}

		public void UpdateData(List<object> dataNew, 
		                       List<object> dataOld,
		                       DataConfig.Lists sheetName = DataConfig.Lists.Main)
		{
			List<List<object>> data = ReadData(sheetName);

			int oldDataIndex = data.FindIndex(el 
				=> el[0].ToString() == dataOld[0].ToString());

			if(oldDataIndex != -1)
			{
				data[oldDataIndex] = dataNew;
				File.WriteAllLines(csvPath, PrepareData(data));
			}
			else
			{
				throw new CustomException(ErrorCodes.Codes.NotExistingData);
			}
		}

		public void DeleteData(DataConfig.Lists sheetName = DataConfig.Lists.Main, int row = -1)
		{
			if(row == -1)
			{
				throw new CustomException(ErrorCodes.Codes.NotExistingData);
			}

			List<List<object>> data = ReadData(sheetName);

			data.RemoveAt(row);
			WriteData(data);
		}
	}
}
