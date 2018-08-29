using System;
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

		public int AddCashToBalance(int amount)
		{
			GSWorker.Instance.TestPlayerBalance += amount;

			return 0;
		}

		public int GetPlayerCash(string steamId = null)
		{
			if(steamId != null)
			{
				try
				{
					List<object> playerInfo = GSWorker.Instance.ReadDataFromSheet(rangeCols: "A1:C")
					.Single(el => el.ElementAt(0).ToString() == steamId);

					if(playerInfo.ElementAt(2) == null)
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
			else
			{
				return 0;
			}
		}
	}
}
