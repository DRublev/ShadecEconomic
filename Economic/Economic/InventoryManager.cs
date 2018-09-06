using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic
{
	public class InventoryManager
	{
		private ISheetDataWorker dataWorker;

		public InventoryManager()
		{
			dataWorker = new ExcelDataWorker();
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
				playerInfo = dataWorker.ReadData("test", "A1:D")
					.Single(item => item.First().ToString() == steamId);

				if (string.IsNullOrEmpty(playerInfo.ElementAt(3).ToString()))
				{
					return "Empty loadout";
				}

				loadout = playerInfo.ElementAt(3).ToString();
			}
			catch
			{
				return string.Empty;
			}

			return loadout;
		}

		public void SetPlayerSavedInventory(string steamId, string loadout)
		{
			if (string.IsNullOrEmpty(steamId) || 
				string.IsNullOrEmpty(loadout))
			{
				return;
			}

			try
			{
				List<object> oldPlayerData = dataWorker.ReadData("test", "")
					.Single(el => el.ElementAt(0).ToString() == steamId);

				oldPlayerData[3] = loadout;
				dataWorker.UpdateData(oldPlayerData, "test", "");
			}
			catch
			{
				return;
			}
		}
	}
}
