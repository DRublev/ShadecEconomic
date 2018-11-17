using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic
{
	public static class StringExtension
	{
		public static List<string> ParseLoadoutToList(this string loadout, List<string> parsed)
		{
			// split string to items without []
			
			if(isItemsContainer(loadout))
			{
				parsed.AddRange(SplitToItems(loadout));
				
				parsed.ForEach(item =>
				{
					if(isItemsContainer(item))
					{
						parsed.AddRange(ParseLoadoutToList(item, parsed));
					}
				});
			}
			
			
			return parsed;
		}

		public static bool isItemsContainer(this string candidate)
		{
			bool isContainer = false;

			int openBracePos = candidate.IndexOf('[');
			int closeBracePos = candidate.LastIndexOf(']');

			isContainer = openBracePos != -1 && closeBracePos != -1;
			
			return isContainer;
		}

		public static string[] SplitToItems(string toSplit)
		{
			string[] splitted = { };
			char[] prepared = { };
			
			toSplit.CopyTo(1, prepared, toSplit.Length - 1, toSplit.Length - 2);
			splitted = prepared.ToString().Split(',');
			
			return splitted;
		}
	}
}