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
			if(availableMethods.ContainsKey(methodName))
			{
				MethodInfo methodInfo = null;
				object callerInstance = null;

				try
				{
					Type callerType = (Type)availableMethods[methodName];
					methodInfo = callerType.GetMethod(methodName);

					callerInstance = Activator.CreateInstance(callerType);
				}
				catch
				{
					return 5;
				}

				return methodInfo.Invoke(callerInstance, arguments);
			}
			else
			{
				// Method with such name not found
				return 2;
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

			char[] arguments = new char[input.Length - methodName.Length];
			input.CopyTo(1, arguments, 0, closeBracePos - 1);

			List<object> args= new List<object>();

			if(input.Contains(","))
			{
				foreach (string argumentString in arguments.ToString().Split(','))
				{
					object argument = argumentString.Trim(' ');
					args.Add(argument.ToString()); 
				}
			}
			else
			{
				args.Add(input.Substring(1, closeBracePos - 1).ToString());
			}

			return (args.ToArray(), methodName);
		}

	}
}