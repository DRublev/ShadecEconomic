using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Economic.Data;
using Economic.Data.Models;
using Economic.Player;

namespace Economic.Items
{
	public class PriceManager
	{
		private readonly IDataHandler dataWorker;

		public PriceManager()
		{
			dataWorker = new CsvDataHandler();
		}

		public int GetItemPrice(string itemClassName, string steamId)
		{
			int price = 0;
			PlayersConfig.Classes playerClass = PlayersConfig.Classes.Pussy;

			if (string.IsNullOrEmpty(itemClassName))
			{
				throw new CustomException(ErrorCodes.Codes.NullData);
			}

			if(string.IsNullOrEmpty(steamId))
			{
				throw new CustomException(ErrorCodes.Codes.NullSteamId);
			}

			List<object> itemInfo = GetItemInfo(itemClassName);
			List<object> playerInfo = new List<object>();

			try
			{
				Console.WriteLine("Trying to get player info");

				var data = dataWorker.ReadData(DataConfig.Lists.Main);

				playerInfo = data.Single(item => item.ElementAt(0).ToString() == steamId);
				Console.WriteLine("Player info getted");

				if (!string.IsNullOrEmpty(playerInfo.ElementAt(2).ToString()))
				{
					playerClass = (PlayersConfig.Classes)playerInfo.ElementAt(2);
				}
			}
			catch
			{
				throw new CustomException(ErrorCodes.Codes.DataReading);
			}

			try
			{
				Console.WriteLine("Trying to get price");
				price = Convert.ToInt32(itemInfo.ElementAt(1).ToString());
				Console.WriteLine("Price getted");
			}
			catch
			{
				throw new CustomException(ErrorCodes.Codes.NullData);
			}

			price = price / 100 * Item.GetDiscount(playerClass, itemClassName);

			return (Item.IsInBlackList(itemClassName)) 
				? throw new CustomException(ErrorCodes.Codes.BlacklistedGear) 
				: price;
		}

		public List<object> GetItemInfo(string itemClassName)
		{
			List<object> itemInfo = dataWorker.ReadData(DataConfig.Lists.Prices)
				.Single(item => item.ElementAt(2).ToString() == itemClassName);
			Console.WriteLine("Successfully get item info");
			return itemInfo;
		}
	}
}
