using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace Economic
{
	public class ExcelDataWorker : ISheetDataWorker
	{
		private Excel.Application app;
		private Excel.Workbook workbook;

		private static string filepath = @"D:/shadec.xlsx";

		public ExcelDataWorker()
		{
			app = new Excel.Application();
			workbook = app.Workbooks.Open(filepath);
		}

		~ExcelDataWorker()
		{
			GC.Collect();
			GC.WaitForPendingFinalizers();
		}

		public List<List<object>> ReadData(string sheetName = "test", string range = "A:D")
		{
			if(string.IsNullOrEmpty(sheetName))
			{
				return new List<List<object>>();
			}

			Excel.Worksheet sheet = workbook.Sheets[sheetName];
			Excel.Range usedRange = sheet.UsedRange;

			List<List<object>> info = new List<List<object>>();

			try
			{
				for (int i = 1; i <= usedRange.Rows.Count; i++)
				{
					List<object> row = new List<object>();

					for (int j = 1; j <= usedRange.Columns.Count; j++)
					{
						if (usedRange.Cells[i, j] != null && usedRange.Cells[i, j].Value2 != null)
						{
							row.Add(usedRange.Cells[i, j].Value2.ToString());
						}
					}

					info.Add(row);
				}
			}
			catch
			{

			}
			finally
			{
				// Cleanup
				GC.Collect();
				GC.WaitForPendingFinalizers();
				Marshal.ReleaseComObject(usedRange);
				Marshal.ReleaseComObject(sheet);
				workbook.Close();
				Marshal.ReleaseComObject(workbook);
				app.Quit();
				Marshal.ReleaseComObject(app);
			}

			return info;
		}

		public void WriteData(List<List<object>> data, string sheetName, string range)
		{

		}

		public void UpdateData(List<object> data, string sheetName, string range)
		{

		}

		public void DeleteData(string sheetName, string range)
		{

		}
	}
}
