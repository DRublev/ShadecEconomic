using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Economic.Data;

namespace Economic.Items
{
	public class PriceManager
	{
		private readonly IDataHandler dataWorker;

		public PriceManager()
		{
			dataWorker = new CsvDataHandler();
		}

		public int GetItemPrice(string itemClassName)
		{
			int price = 0;

			if(string.IsNullOrEmpty(itemClassName))
			{
				throw new CustomException(ErrorCodes.Codes.NullData);
			}

			List<object> itemInfo = GetItemInfo(itemClassName);

			try
			{
				price = Convert.ToInt32(itemInfo.ElementAt(1).ToString());
			}
			catch
			{
				throw new CustomException(ErrorCodes.Codes.NullData);
			}

			return price;
		}

		public List<object> GetItemInfo(string itemClassName)
		{
			List<object> itemInfo = dataWorker.ReadData(DataConfig.Lists.Prices)
				.Single(item => item.ElementAt(2).ToString() == itemClassName);

			return itemInfo;
		}
	}
}
