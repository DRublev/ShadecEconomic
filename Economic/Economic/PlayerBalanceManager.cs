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

		public void SetPlayerCash(int cash, string steamId = null)
		{
			if(steamId == null)
			{
				return;
			}

			try
			{
				List<object> playerInfo = GSWorker.Instance.ReadDataFromSheet(rangeCols: "A:D")
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

			List<object> playerInfo = new List<object>();
			int cash = 0;

			try
			{
				playerInfo = GSWorker.Instance.ReadDataFromSheet("test", "A1:D")
				.Single(item => item.First().ToString() == steamId);

				cash = Convert.ToInt32(playerInfo.ElementAt(2));
			}
			catch
			{
				return 2;
			}

			return cash;
		}

		public int GetBalanceTest()
		{
			return 580;
		}
	}
}
