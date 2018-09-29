using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Economic
{
	public abstract class CustomException : Exception
	{
		private Logger logger = new Logger();

		public CustomException()
		{
		}

		~CustomException()
		{
			logger = null;
		}

		public CustomException(string message) : base(message)
		{
			logger.Log(message);
		}

		public CustomException(string message, Exception inner) : base(message, inner)
		{
		}
	}
}
