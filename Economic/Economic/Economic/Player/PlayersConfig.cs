using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic.Player
{
	public static class PlayersConfig
	{
		public const int DefaultBalance = 5000;
		public static readonly string DefaultInventory = string.Empty;		
		
		public enum Classes
		{
			Pussy,
			Machinegunner,
			Medic,
			Grenadier,
			Rifleman,
			BlastSpecialist,
			Spotter,
			Marksman,
			Sniper,
			AmmoCarrier,
			Engineer
		}
	}
}