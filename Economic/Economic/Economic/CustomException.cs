using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Economic
{
	[SuppressMessage("ReSharper", "PublicConstructorInAbstractClass")]
	public class CustomException : Exception
	{
		private Logger logger = new Logger();

		public CustomException()
		{
			Logger.Log("Custom exception throed without any error code!", this.Source);
		}

		~CustomException()
		{
			logger = null;
		}

		public CustomException(ErrorCodes.Codes code) : base(code.ToString())
		{
			Logger.Log($"{code.ToString()} {code.GetDescription()}", this.Source);
		}

		public CustomException(ErrorCodes.Codes code, Exception inner) : base(code.ToString(), inner)
		{
			
		}
	}

	public static class ErrorCodes
	{
		public enum Codes : int
		{
			[Description("Null data")]
			NullData = 001,
			
			[Description("Everything is alright")]
			Ok = 100,
			
			[Description("Everything is alright")]
			MethodCallParse = 101,
			
			[Description("Everything is alright")]
			MethodNotFound = 102,
			
			[Description("Everything is alright")]
			WrongArgsList = 103,
			
			[Description("Everything is alright")]
			MethodCall = 104,
			
			[Description("Everything is alright")]
			MethodCash = 105,
			
			[Description("Everything is alright")]
			DataFileNotFound = 201,
			
			[Description("Everything is alright")]
			DataReading = 202,
			
			[Description("Everything is alright")]
			DataWriting = 203,
			
			[Description("Everything is alright")]
			NotExistingData = 204,
			
			[Description("Everything is alright")]
			NullSteamId = 300,
			
			[Description("Everything is alright")]
			WrongSteamId = 301
		}
		
		public static string GetDescription(this Codes value)
		{
			Type type = value.GetType();
			string name = Enum.GetName(type, value);
			
			if(name == null) return null;
			
			FieldInfo field = type.GetField(name);

			if(field == null) return null;
				
			DescriptionAttribute attr = 
				(DescriptionAttribute) Attribute.GetCustomAttribute(field, 
					typeof(DescriptionAttribute));

			return attr?.Description;
		}
	}
}
