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
			List<object> playerInfo = new List<object>();

			try
			{
				List<List<object>> allInfo = GSWorker.Instance.ReadDataFromSheet();
				
				if(!allInfo.Exists(item => item.ElementAt(0).ToString() == steamId))
				{
					return $"Can't find loadout with this steamId: {steamId}";
				}

				playerInfo = allInfo.Single(item => item.ElementAt(0).ToString() == steamId);
			}
			catch (Exception ex)
			{
				return $"Exception: {ex.StackTrace}";
			}

			if (playerInfo.ElementAt(3) == null)
			{
				return "Empty loadout";
			}

			try
			{
				loadout = playerInfo.ElementAt(3).ToString();
			}
			catch(Exception ex)
			{
				return $"Can't get loadout: {ex.Message}";
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
