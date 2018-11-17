using Economic.Player;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic.Data.Models
{
	public static class Item
	{
		public static bool IsInBlackList(string item)
		{
			bool isBlacklisted = false;



			return isBlacklisted;
		}

		public static int GetDiscount(PlayersConfig.Classes classname, string item)
		{
			int discount = 1;

			foreach(KeyValuePair<ItemDiscount, PlayersConfig.Classes> discountObj in PlayersConfig.Discounts.Values)
			{
				if(discountObj.Value == classname)
				{
					if(discountObj.Key.Item == item)
					{
						discount = discountObj.Key.Discount;
					}
				}
			}

			return discount;
		}
	}

	// TODO: Move validation logic to Model

	/*
	* Just move validation into base constructor
	* And just call concrete constructor: public Item() : base()
	* Or smth like that
	*/
	public class ItemM : Model
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public double Price { get; set; }

		private ItemM() { }

		public ItemM(string name, double price)
		{
			ItemM item = new ItemM()
			{
				Name = name,
				Price = price
			};

			ValidationContext validation = new ValidationContext(item, null, null);
			List<ValidationResult> results = new List<ValidationResult>();
			bool isValid = Validator.TryValidateObject(item, validation, results);

			if(!isValid)
			{
				throw new CustomException(ErrorCodes.Codes.ValidationFailed);
			}
			else
			{
				Name = item.Name;
				Price = item.Price;

				DataCasher.Instance.CacheObject(item);
			}
		}
	}
}
