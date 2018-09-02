using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic
{
	public class InventoryManager
	{
		public string GetPlayerSavedLoadout(string steamId = null)
		{
			if(steamId == null)
			{
				return string.Empty;
			}

			string loadout = string.Empty;

			try
			{
				List<object> playerInfo = GSWorker.Instance.ReadDataFromSheet()
					.Single(el => el.ElementAt(0).ToString() == steamId);

				if(playerInfo.ElementAt(3) == null)
				{
					return "Empty loadout";
				}

				loadout = playerInfo.ElementAt(3).ToString();
			}
			catch
			{
				return "Exception";
			}

			return loadout;
		}

		public void SetPlayerSavedInventory(string steamId = null, string items = "")
		{
			if(steamId == null)
			{
				return;
			}

			try
			{
				List<object> oldPlayerData = GSWorker.Instance.ReadDataFromSheet()
					.Single(el => el.ElementAt(0).ToString() == steamId);

				oldPlayerData[3] = items;

				GSWorker.Instance.UpdateDataInSheet(oldPlayerData);
			}
			catch
			{
				return;
			}
		}
	}
}
