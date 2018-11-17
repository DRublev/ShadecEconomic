using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Economic.Data;

namespace Economic.Player
{
	public class PlayerHandler
	{
		private IDataHandler dataHandler = new CsvDataHandler();
		
		public bool isNewPlayer(string steamId)
		{
			bool isNew = true;

			List<List<object>> allData = dataHandler.ReadData(DataConfig.Lists.Main);
			
			try
			{
				allData.ForEach(data =>
				{
					/*if(string.IsNullOrEmpty(data.ElementAt(0).ToString()))
					{
						throw new CustomException(ErrorCodes.Codes.NullSteamId);
					}*/

					if (data.ElementAt(0).ToString() != steamId && !isNew)
					{
						Console.WriteLine($"{data.ElementAt(0).ToString()} is new player");
						isNew = true;
					}
					else if (data.ElementAt(0).ToString() == steamId && isNew)
					{
						Console.WriteLine($"{data.ElementAt(0).ToString()} is old player");
						isNew = false;
					}
				});
			}
			catch
			{
				throw new CustomException(ErrorCodes.Codes.DataReading);
			}
			
			return isNew;
		}

		private void CreateNewPlayer(string steamId)
		{
			if(string.IsNullOrEmpty(steamId))
			{
				throw new CustomException(ErrorCodes.Codes.NullSteamId);
			}
			
			List<object> newPlayerData = new List<object>()
			{
				steamId,
				PlayersConfig.Classes.Pussy,
				PlayersConfig.DefaultBalance,
				PlayersConfig.DefaultInventory
			};
			
			dataHandler.WriteData(new List<List<object>>()
			{
				newPlayerData
			},
			DataConfig.Lists.Main);
		}

		public void CheckNewPLayerExistence(string steamId)
		{
			if(isNewPlayer(steamId))
			{
				CreateNewPlayer(steamId);
			}
		}
	}
}