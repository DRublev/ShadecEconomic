using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic
{
	public class PlayerBalanceManager
	{
		private IDataHandler dataWorker;

		public PlayerBalanceManager()
		{
			dataWorker = new CsvDataHandler();
		}

		public void SetPlayerCash(int cash, string steamId = null)
		{
			if(steamId == null)
			{
				return;
			}

			try
			{
				List<object> playerInfo = dataWorker.ReadData("test")
					.Single(el => el.ElementAt(0).ToString() == steamId);

				if(playerInfo == null)
				{

					throw new Exception("Player is null");
				}

				List<object> newInfo = playerInfo;
				newInfo[2] = (object)cash;

				dataWorker.UpdateData(newInfo, playerInfo, "test");
			}
			catch(Exception ex)
			{
				throw ex;
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
				playerInfo = dataWorker.ReadData("test")
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
