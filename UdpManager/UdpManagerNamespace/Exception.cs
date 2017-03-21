using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdpManagerNamespace
{
	class NoVaildIpV4AddressException : ApplicationException
	{
		public NoVaildIpV4AddressException(string message)
		{
			Message = message;
		}

		public override string Message { get; }
	}

	class UdpManagerNotInitializeException : ApplicationException
	{
		public UdpManagerNotInitializeException(string message)
		{
			Message = message;
		}

		public override string Message { get; }
	}
}
