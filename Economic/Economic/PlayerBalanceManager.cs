using System;
using System.Collections.Generic;
using System.Linq;

namespace Economic
{
	public class PlayerBalanceManager
	{
		public PlayerBalanceManager()
		{

		}

		public int AddCashToBalance(int amount)
		{
			if (steamId == null)
			{
				return;
			}

			try
			{
				List<object> playerInfo = GSWorker.Instance.ReadDataFromSheet(rangeCols: "A1:D")
					.Single(el => el.ElementAt(0).ToString() == steamId);
				GSWorker.Instance.TestPlayerBalance += amount;

				return 0;
			}

		public int GetPlayerCash(string steamId = null)
			{
				if (steamId != null)
				{
					try
					{
						List<object> playerInfo = GSWorker.Instance.ReadDataFromSheet(rangeCols: "A1:C")
						.Single(el => el.ElementAt(0).ToString() == steamId);

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
						catch
						{
							return 1;
						}
					}
					catch (Exception ex)
					{

					}
			else
			{
						return 0;
					}
				}
			}
		}
