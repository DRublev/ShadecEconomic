using Economic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomicTests
{
	[TestClass]
	public class MethodCallerTests
	{
		[TestMethod]
		public void ParseInputTest()
		{
			string inputExample = @"[129,111]SetPlayerCash";

			(object[] args, string methodName) expected =
				(
					new object[2] { "129", "111" },
					"SetPlayerCash"
				);
			(object[] args, string methodName) actual = MethodCaller.Instance.ParseInput(inputExample);

			Assert.IsTrue(expected.methodName == actual.methodName
				&& expected.args.Count() == actual.args.Count());
		}

		[TestMethod]
		public void CallGetPlayerCashTest()
		{
			string callCommand = @"[129]GetPlayerCash";

			(object[] args, string methodName) parsedCommand = MethodCaller.Instance.ParseInput(callCommand);

			object result = MethodCaller.Instance.Call(parsedCommand.methodName, parsedCommand.args);

			Assert.IsTrue(Convert.ToInt32(result) == 8000);
		}
	}
}
