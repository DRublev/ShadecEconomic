using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Maca134.Arma.DllExport;

namespace Economic
{
    public class Entry
    {
		[ArmaDllExport]
		public static string Invoke(string input, int size)
		{
			/*(object[] args, string methodName) parameters = MethodCaller.Instance.ParseInput(input);
			object result = MethodCaller.Instance.Call(parameters.methodName, parameters.args);*/

			var result = MethodCaller.Instance.Call("GetPlayerCash", new object[] { "76561198140185053" });

			return $"{result.ToString()}";
		}
	}
}