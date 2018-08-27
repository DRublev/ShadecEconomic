using System;
using System.Collections.Generic;
using System.Linq;
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
			return "Works: " + input;
		}
    }
}