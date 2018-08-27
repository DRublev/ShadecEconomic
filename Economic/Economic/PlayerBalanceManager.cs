using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic
{
	public class PlayerBalanceManager
	{
		public int AddCashToBalance(int amount)
		{
			GSWorker.Instance.TestPlayerBalance += amount;

			return 0;
		}

		public int GetPlayerCash(string steamId = null)
		{
			if(steamId != null)
			{
				return GSWorker.Instance.TestPlayerBalance;
			}
			else
			{
				return 0;
			}
		}
	}
}
