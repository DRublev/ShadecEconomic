using System;
using Economic.Player;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EconomicTest
{
	[TestClass]
	public class PlayerHandlerTests
	{
		private PlayerHandler ph = new PlayerHandler();

		[TestMethod]
		public void CheckOldPlayerExistanceTest()
		{
			bool isNew = ph.isNewPlayer("128");

			Assert.IsFalse(isNew);
		}

		[TestMethod]
		public void CheckNewPlayerExistanceTest()
		{
			bool isNew = ph.isNewPlayer("125");

			Assert.IsTrue(isNew);
		}
	}
}
