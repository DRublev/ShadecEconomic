using Economic.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic.Data
{
	public class DataCasher
	{
		private static DataCasher instance = null;
		public static DataCasher Instance
		{
			get
			{
				if(Equals(instance, null))
				{
					instance = new DataCasher();
				}

				return instance;
			}
		}

		public Hashtable Prices = new Hashtable();
		public Hashtable Players = new Hashtable();

		public void CacheObject(object toCache)
		{
			switch(toCache.GetType().Name)
			{
				case "Player":
					Models.Player player = toCache as Models.Player;
					Players.Add(player.SteamId, toCache);
					break;
				case "Item":
					ItemM item = toCache as ItemM;
					Prices.Add(item.Name, item.Price);
					break;
				default:
					throw new CustomException(ErrorCodes.Codes.UnknownError);
			}
		}
	}
}
