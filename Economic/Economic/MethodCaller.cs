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
				try
				{
					Type callerType = (Type)availableMethods[methodName];
					MethodInfo methodInfo = callerType.GetMethod(methodName);

					object callerInstance = Activator.CreateInstance(callerType);

					return methodInfo.Invoke(callerInstance, BindingFlags.CreateInstance, null, arguments, null);
				}
				catch (Exception ex)
				{
					// TODO: Log or not? That's the question

					return 1;
				}
			}
			else
			{
				// Method with such name not found
				return 2;
			}
		}

		/*~MethodCaller()
		{
			availableMethods = null;
		}*/
	}
}