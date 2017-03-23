using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using TcpUdpManagerNamespace;
using TimerManagerNamespace;

namespace Main
{
	class Program
	{
		private static void Print(byte[] argBytes)
		{
			Console.WriteLine(Encoding.ASCII.GetString(argBytes));
		}

		static void Main(string[] args)
		{
			//TCP SERVER
			/*
			TcpManager targetTcpManager = TcpManager.GetInstance();
			targetTcpManager.InitTcpServer(10000,Print);
			*/

			//TCP CLIENT
			/*
			TcpManager targetTcpManager = TcpManager.GetInstance();
			IPEndPoint remote = new IPEndPoint(targetTcpManager.HostIpAddress,10001);
			targetTcpManager.InitTcpClient(remote, Print);

			Console.ReadLine();
			targetTcpManager.TcpClientClose();
			*/


			//UDP
			/*
			UdpManager targetUdpManager = UdpManager.GetInstance();
			targetUdpManager.InitUdp(10000, Print);
			targetUdpManager.Send(targetUdpManager.HostIpAddress, 10001, "asdasdasdas");
			*/

			Console.ReadLine();
		}
	}
}
