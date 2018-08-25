using System;
using Economic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EconomicTests
{
	[TestClass]
	public class FileReaderTests
	{
		[TestMethod]
		public void ReadFileTest()
		{
			string expected = "Hello Arma!";
			string actual = FileReader.ReadFile(@"C:\Users\aring\Desktop\Job\Projects\Personal\ShadecEconomic\Economic\Economic\test.txt");

			Assert.AreEqual(expected, actual);
		}
	}
}
