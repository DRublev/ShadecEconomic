using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Economic.Data;
using Economic.Player;

namespace Economic
{
	public class PlayerBalanceManager
	{
		private IDataHandler dataWorker;
		private PlayerHandler playerHandler;

		public PlayerBalanceManager()
		{
			dataWorker = new CsvDataHandler();
			playerHandler = new PlayerHandler();
		}

		public void SetPlayerCash(int cash, string steamId = null)
		{
			if(string.IsNullOrEmpty(steamId))
			{
				throw new CustomException(
					ErrorCodes.Codes.NullSteamId);
			}

			try
			{
				List<object> playerInfo = dataWorker.ReadData(DataConfig.Lists.Main)
					.Single(el => el.ElementAt(0).ToString() == steamId);

				if(playerInfo == null)
				{
					throw new CustomException(
						ErrorCodes.Codes.NotExistingData);
				}

				List<object> newInfo = playerInfo;
				newInfo[2] = (object)cash;

				dataWorker.UpdateData(newInfo, playerInfo, DataConfig.Lists.Main);
			}
			catch(Exception ex)
			{
				throw new CustomException(
					ErrorCodes.Codes.DataReading);
			}
		}

		public int GetPlayerCash(string steamId = null)
		{
			if (string.IsNullOrEmpty(steamId))
			{
				throw new CustomException(
					ErrorCodes.Codes.NullSteamId);
			}
			playerHandler.CheckNewPLayerExistence(steamId);

			List<object> playerInfo = new List<object>();
			int cash = 0;

			try
			{
				playerInfo = dataWorker.ReadData(DataConfig.Lists.Main)
					.Single(item => item.First().ToString() == steamId);

				cash = Convert.ToInt32(playerInfo.ElementAt(2));
			}
			catch
			{
				throw new CustomException(
					ErrorCodes.Codes.NotExistingData);
			}

			return cash;
		}
	}
}
