using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TcpUdpManagerNamespace;
using TimerManagerNamespace;

namespace Main
{
	class Program
	{
		static void Main(string[] args)
		{
			UdpManager targetUdpManager = UdpManager.GetInstance();
			targetUdpManager.Init(10000);
			targetUdpManager.Send(targetUdpManager.HostIpAddress, 10001, "asdasdasdas");



			Console.ReadLine();
		}
	}
}
