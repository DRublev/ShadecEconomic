using Economic.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Economic.Player.PlayersConfig;
using System.ComponentModel.DataAnnotations;

namespace Economic.Data.Models
{
	public class Player : Model
	{
		[StringLength(17), Required]
		[RegularExpression(@"^[0-9]$")]
		public string SteamId { get; set; }
		[Required]
		public Classes Class { get; set; }
		[Required]
		public double Balance { get; set; }
		[Required]
		public string Inventory { get; set; }

		private Player() { }

		public Player(
			string steamId, 
			Classes _class,
			double balace,
			string inventory)
		{
			Player p = new Player()
			{
				SteamId = steamId,
				Class = _class,
				Balance = balace,
				Inventory = inventory
			};

			ValidationContext validation = new ValidationContext(p, null, null);
			List<ValidationResult> results = new List<ValidationResult>();
			bool isValid = Validator.TryValidateObject(p, validation, results);

			if(!isValid)
			{
				throw new CustomException(ErrorCodes.Codes.ValidationFailed);
			}
			else
			{
				SteamId = p.SteamId;
				Class = p.Class;
				Balance = p.Balance;
				Inventory = p.Inventory;

				DataCasher.Instance.CacheObject(p);
			}
		}
	}
}
