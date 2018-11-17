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
			(object[] args, string methodName) parameters = MethodCaller.Instance.ParseInput(input);
			
			
			try
			{
				object result = MethodCaller.Instance.Call(parameters.methodName, parameters.args);

				return $"{result.ToString()}";
			}
			catch(CustomException ex)
			{
				Console.WriteLine((int) ex.Code);
				return $"{((int)ex.Code).ToString()}";
			}
			catch(Exception ex)
			{
				return "Unknown exception";
			}
		}
	}
}