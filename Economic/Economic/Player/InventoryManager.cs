using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Economic.Data;
using Economic.Items;

namespace Economic.Player
{
	public class InventoryManager
	{
		private IDataHandler dataWorker;
		private PriceManager pm = new PriceManager();

		public InventoryManager()
		{
			dataWorker = new CsvDataHandler();
		}
		
		public string GetPlayerSavedLoadout(string steamId)
		{
			if(string.IsNullOrEmpty(steamId))
			{
				return string.Empty;
			}

			List<object> playerInfo = new List<object>();
			string loadout = string.Empty;

			try
			{
				playerInfo = dataWorker.ReadData(DataConfig.Lists.Main)
					.Single(item => item.First().ToString() == steamId);

				if (string.IsNullOrEmpty(playerInfo.ElementAt(3).ToString()))
				{
					throw new CustomException(ErrorCodes.Codes.GetLoadoutFailed);
				}

				loadout = playerInfo.ElementAt(3).ToString();
			}
			catch
			{
				throw new CustomException(ErrorCodes.Codes.DataReading);
			}

			return loadout;
		}

		public void SetPlayerSavedInventory(string steamId, string loadout)
		{
			if (string.IsNullOrEmpty(steamId) || 
				string.IsNullOrEmpty(loadout))
			{
				throw new CustomException(ErrorCodes.Codes.NullData);
			}

			try
			{
				List<object> oldPlayerData = dataWorker.ReadData(DataConfig.Lists.Main)
					.Single(el => el.ElementAt(0).ToString() == steamId);

				List<object> newPlayerData = oldPlayerData;
				newPlayerData[3] = loadout;
				dataWorker.UpdateData(newPlayerData, oldPlayerData, DataConfig.Lists.Main);
			}
			catch
			{
				return;
			}
		}

		public int NewGearCost(string old, string newOne, string steamId)
		{
			int cost = 0;

			int oldPrice = 0;
			int newPrice = 0;

			if (string.IsNullOrEmpty(steamId))
			{
				throw new CustomException(ErrorCodes.Codes.NullSteamId);
			}

			List<string> oldItems = new List<string>();
			List<string> newItems = new List<string>();
			
			old.ParseLoadoutToList(oldItems);
			newOne.ParseLoadoutToList(newItems);
			
			oldItems.ForEach(item => oldPrice += pm.GetItemPrice(item, steamId));
			newItems.ForEach(item => newPrice += pm.GetItemPrice(item, steamId));

			cost = newPrice - oldPrice;

			return cost;
		}
	}
}
