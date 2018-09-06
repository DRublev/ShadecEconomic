using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic
{
	public interface ISheetDataWorker
	{
		List<List<object>> ReadData(string sheetName, string range);
		void WriteData(List<List<object>> data, string sheetName, string range);
		void UpdateData(List<object> data, string sheetName, string range);
		void DeleteData(string sheetName, string range);
	}
}
