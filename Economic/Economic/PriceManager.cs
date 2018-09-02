﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic
{
	public class PriceManager
	{
		private const string pricesSheetName = "prices";

		public int GetItemPrice(string itemClassName)
		{
			int price = 0;

			if(itemClassName == null || itemClassName == string.Empty)
			{
				return 1;
			}

			List<object> itemInfo = new List<object>();

			try
			{
				GSWorker.Instance.ReadDataFromSheet(pricesSheetName, "A:C")
					.ForEach(item =>
					{
						if (item.Count == 3)
						{
							if (item.ElementAt(2).ToString() == itemClassName)
							{
								itemInfo = item;
							}
						}
					});

				price = Convert.ToInt32(itemInfo.ElementAt(1));
			}
			catch
			{
				return 2;
			}

			return price;
		}

		public List<object> GetItemInfo(string itemClassName)
		{
			List<object> itemInfo = new List<object>();

			GSWorker.Instance.ReadDataFromSheet(pricesSheetName, "A:C")
			.ForEach(item =>
			{
				if (item.Count == 3)
				{
					if (item.ElementAt(2).ToString() == itemClassName)
					{
						itemInfo = item;
					}
				}
			});

			return itemInfo;
		}
	}
}
