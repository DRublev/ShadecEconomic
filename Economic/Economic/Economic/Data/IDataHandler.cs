using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Economic.Data;

namespace Economic.Data
{
	public interface IDataHandler
	{
		bool isDataExist(List<object> data);
		List<List<object>> ReadData(DataConfig.Lists sheetName);
		void WriteData(List<List<object>> data, DataConfig.Lists sheetName);
		void UpdateData(List<object> dataNew, List<object> dataOld, DataConfig.Lists sheetName);
		void DeleteData(DataConfig.Lists sheetName, int row);
	}
}
