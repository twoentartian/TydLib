using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TcpManagerNamespace;

namespace Main
{
	class Program
	{
		static void Main(string[] args)
		{
			TcpManager targetManager = TcpManager.GetInstance();

			/*
			targetManager.InitTcpServer(10000);
			targetManager.TcpServerStartListenTask();
			Console.ReadLine();

			Guid temp = targetManager.TcpServerGetGuid(targetManager.HostIpAddress);
			targetManager.TcpServerSend(temp, "123321" + Environment.NewLine);
			Console.ReadLine();

			targetManager.TcpServerStopAllClient();
			*/

			
			IPEndPoint remotEndPoint = new IPEndPoint(IPAddress.Parse("192.168.1.116"), 10001);
			try
			{
				targetManager.InitTcpClient(remotEndPoint);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}

			targetManager.TcpClientSend("123");
			Console.ReadLine();
			targetManager.TcpClientSend("123");
			Console.ReadLine();
			targetManager.TcpClientClose();
		}
	}
}
