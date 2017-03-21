using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UdpManagerNamespace;

namespace Main
{
	class Program
	{
		static void Main(string[] args)
		{
			UdpManager tempUdpManager = UdpManager.GetInstance();
			tempUdpManager.Init(10000);
			tempUdpManager.Send(IPAddress.Broadcast, 10001, "Hello");
			Console.ReadLine();
		}
	}
}
