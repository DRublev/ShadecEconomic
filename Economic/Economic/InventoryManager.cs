﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic
{
	public class InventoryManager
	{
		private IDataHandler dataWorker;

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
				playerInfo = dataWorker.ReadData("test")
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
				List<object> oldPlayerData = dataWorker.ReadData("test")
					.Single(el => el.ElementAt(0).ToString() == steamId);

				List<object> newPlayerData = oldPlayerData;
				newPlayerData[3] = loadout;
				dataWorker.UpdateData(newPlayerData, oldPlayerData, "test");
			}
			catch
			{
				return;
			}
		}

		public int NewGearCost(string old, string newOne)
		{
			int cost = 0;



			return cost;
		}
	}
}
