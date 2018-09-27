using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic
{
	public interface IDataHandler
	{
		List<List<object>> ReadData(string sheetName);
		void WriteData(List<List<object>> data, string sheetName);
		void UpdateData(List<object> dataNew, List<object> dataOld, string sheetName);
		void DeleteData(string sheetName, int row);
	}
}
