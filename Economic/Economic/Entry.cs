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
		public static string Invoke(string methodName, int size)
		{
			object result = MethodCaller.Instance.Call(methodName);

			return $"Result of magic execution: {result}";
		}

		[ArmaDllExport]
		public static int RvExtensionArgs(string methodName,
			int size,
			[MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 4)] string[] args,
			int argCount)
		{
			object result = MethodCaller.Instance.Call(methodName, args);

			return (result == null) ? 1 : 0;
		}
	}
}