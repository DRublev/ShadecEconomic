using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Economic
{
	public class MethodCaller
	{
		private static MethodCaller instance = null;
		public static MethodCaller Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new MethodCaller();
				}

				return instance;
			}
		}

		/// <summary>
		/// All methods in executing namespace. 
		/// Key - method name
		/// Value - method's caller class Type
		/// </summary>
		private Hashtable availableMethods = new Hashtable();

		private MethodCaller()
		{
			FindNCashAllMethods();
		}

		private List<Type> typesInExecutableAssembly
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetTypes().ToList();
			}
		}
		private List<MethodInfo> GetTypeMethods(Type type)
		{
			return type.GetMethods().ToList();
		}
		private void FindNCashAllMethods()
		{
			typesInExecutableAssembly.ForEach(t =>
			{
				GetTypeMethods(t).ForEach(m =>
				{
					if (!availableMethods.ContainsKey(m.Name))
					{
						availableMethods.Add(m.Name, t);
					}
				});
			});
		}

		/// <summary>
		/// Call method by name
		/// </summary>
		/// <param name="methodName"></param>
		/// <param name="arguments"></param>
		/// <returns></returns>
		public object Call(string methodName, object[] arguments)
		{
			try
			{
				if (availableMethods.ContainsKey(methodName))
				{
					try
					{
						Type callerType = (Type)availableMethods[methodName];
						MethodInfo methodInfo = callerType.GetMethod(methodName);

						object callerInstance = Activator.CreateInstance(callerType, true);

						return methodInfo.Invoke(callerInstance, BindingFlags.CreateInstance, null, arguments, null);
					}
					catch (Exception ex)
					{
						return $"Call method error: {ex.InnerException.GetType()} {ex.InnerException.StackTrace}";
					}
				}
				else
				{
					// Method with such name not found
					return $"Method with such name doesn't exist";
				}
			}
			catch(Exception ex)
			{
				return $"Can't call method, error: {ex.GetType()}";
			}
		}

		/// <summary>
		/// Use this to process the input string from SQf to MethodCaller.Call() parameters
		/// </summary>
		/// <param name="input">Must have format "[arg1, ..., argN]functionName"</param>
		/// <returns>Method name to call and arguments to pass to that method</returns>
		public (object[] args, string methodName) ParseInput(string input)
		{
			int closeBracePos = input.LastIndexOf(']');

			string methodName = input.Substring(closeBracePos + 1);

			char[] arguments = new char[100];
			input.CopyTo(1, arguments, 0, closeBracePos - 1);

			List<object> args = new List<object>();

			if(input.Contains(","))
			{
				string[] splitted = arguments.ToString().Split(',');
				foreach (string argumentString in splitted)
				{
					object argument = argumentString.Trim(' ');
					args.Add(argument);
				}
			}
			else
			{
				args.Add(input.Substring(1, closeBracePos - 1));
			}

			return (args.ToArray(), methodName);
		}

		~MethodCaller()
		{
			availableMethods = null;
		}
	}
}