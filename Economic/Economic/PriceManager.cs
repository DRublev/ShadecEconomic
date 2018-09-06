using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic
{
	public class PriceManager
	{
		private const string pricesSheetName = "prices";

		private ISheetDataWorker dataWorker;

		public PriceManager()
		{
			dataWorker = new ExcelDataWorker();
		}

		public int GetItemPrice(string itemClassName)
		{
			int price = 0;

			if(itemClassName == null || itemClassName == string.Empty)
			{
				return 1;
			}

			List<object> itemInfo = new List<object>();

			try
			{
				itemInfo = dataWorker.ReadData("prices", "A1:D")
					.Single(item => item.Last().ToString() == itemClassName);

				price = Convert.ToInt32(itemInfo.ElementAt(1));
			}
			catch
			{
				return 2;
			}

			return price;
		}

		public List<object> GetItemInfo(string itemClassName)
		{
			List<object> itemInfo = GSDataWorker.Instance.ReadData(pricesSheetName, "A1:C")
				.Single(item => item.ElementAt(2).ToString() == itemClassName);

			return itemInfo;
		}
	}
}
