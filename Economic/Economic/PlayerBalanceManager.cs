﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic
{
	public class PlayerBalanceManager
	{
		public PlayerBalanceManager()
		{

		}

		public void SetPlayerCash(int cash, string steamId = null)
		{
			if(steamId == null)
			{
				return;
			}

			try
			{
				List<object> playerInfo = GSWorker.Instance.ReadDataFromSheet(rangeCols: "A1:D")
					.Single(el => el.ElementAt(0).ToString() == steamId);

				playerInfo[2] = (object)cash;

				GSWorker.Instance.UpdateDataInSheet(playerInfo);
			}
			catch
			{
				return;
			}
		}

		public int GetPlayerCash(string steamId = null)
		{
			if(steamId == null)
			{
				return 0;
			}

			try
			{
				List<object> playerInfo = GSWorker.Instance.ReadDataFromSheet(rangeCols: "A:D")
					.Single(el => el.ElementAt(0).ToString() == steamId);

				if (playerInfo.ElementAt(2) == null)
				{
					return 2;
				}

				return Convert.ToInt32(playerInfo.ElementAt(2));
			}
			catch(Exception ex)
			{
				return 1;
			}
		}
	}
}