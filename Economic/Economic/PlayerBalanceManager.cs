using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic
{
	public class PlayerBalanceManager
	{
		private ISheetDataWorker dataWorker;

		public PlayerBalanceManager()
		{
			dataWorker = new CsvDataWorker();
		}

		public void SetPlayerCash(int cash, string steamId = null)
		{
			if(steamId == null)
			{
				return;
			}

			try
			{
				List<object> playerInfo = GSDataWorker.Instance.ReadData(rangeCols: "A:D")
					.Single(el => el.ElementAt(0).ToString() == steamId);

				playerInfo[2] = (object)cash;

				GSDataWorker.Instance.UpdateData(playerInfo);
			}
			catch
			{
				return;
			}
		}

		public int GetPlayerCash(string steamId = null)
		{

			if (steamId == null)
			{
				return 0;
			}

			List<object> playerInfo = new List<object>();
			int cash = 0;

			try
			{
				playerInfo = dataWorker.ReadData("test", "A1:D")
				.Single(item => item.First().ToString() == steamId);

				cash = Convert.ToInt32(playerInfo.ElementAt(2));
			}
			catch
			{
				return 2;
			}

			return cash;
		}
	}
}
