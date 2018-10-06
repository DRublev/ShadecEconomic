using System;
using Economic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EconomicTests
{
	[TestClass]
	public class PlayerBalanceManagerTests
	{
		[TestMethod]
		public void GetPlayerCashTest()
		{
			PlayerBalanceManager balanceManager = new PlayerBalanceManager();
			string steamId = "129";

			int actualBalance = balanceManager.GetPlayerCash(steamId);
			int expectedBalance = 8000;
			Assert.IsTrue(expectedBalance == actualBalance);
		}

		[TestMethod]
		public void SetPlayerCashTest()
		{
			PlayerBalanceManager balanceManager = new PlayerBalanceManager();
			string steamId = "129";
			int cash = 8020;

			try
			{
				balanceManager.SetPlayerCash(cash, steamId);
			}
			catch(Exception ex)
			{
				throw ex;
			}

			int afterSet = balanceManager.GetPlayerCash(steamId);
			balanceManager.SetPlayerCash(8000, steamId);

			Assert.IsTrue(cash == afterSet);
		}
	}
}
