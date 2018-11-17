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
		public ErrorCodes.Codes Code = ErrorCodes.Codes.Ok;

		public CustomException()
		{
			Logger.Log("Custom exception throwed without any error code!", this.Source);
		}

		public CustomException(ErrorCodes.Codes code) : base(code.ToString())
		{
			Logger.Log($"{code.ToString()} {code.GetDescription()}", this.Source.ToString());
			Code = code;
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
			
			[Description("Can't parse method-calling string")]
			MethodCallParse = 101,
			
			[Description("Method not found")]
			MethodNotFound = 102,
			
			[Description("Method with this arguments can't be called")]
			WrongArgsList = 103,
			
			[Description("Method calling error")]
			MethodCall = 104,
			
			[Description("Error while cashing method")]
			MethodCache = 105,
			
			[Description("Alarm! Somebody has stolen our data!")]
			DataFileNotFound = 201,
			
			[Description("Data reading error")]
			DataReading = 202,
			
			[Description("Data writing error")]
			DataWriting = 203,
			
			[Description("Ur trying to access not existing data")]
			NotExistingData = 204,
			
			[Description("Give me any steam id, soab!")]
			NullSteamId = 300,
			
			[Description("Wrong steam id")]
			WrongSteamId = 301,

			[Description("Data validation failed")]
			ValidationFailed = 302,

			[Description("Gear is in blacklist")]
			BlacklistedGear = 400,

			[Description("Gettion player's loadout failed")]
			GetLoadoutFailed = 401,

			[Description("Unknow error")]
			UnknownError = 404
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
