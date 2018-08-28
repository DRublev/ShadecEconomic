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
			object result = MethodCaller.Instance.Call(methodName, new object[1] { "780313154646" });
			
			return $"{result}";
		}
	}
}