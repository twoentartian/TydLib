using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

using TcpUdpManagerNamespace;
using TimerManagerNamespace;
using SerialPortNamespace;

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


			//Serial
			/*
			SerialManager tempSerialManager = SerialManager.GetInstance();
			string[] targets =  SerialManager.GetAllVaildPorts();
			SerialManager.SerialPortWithGuid temp =  tempSerialManager.Add(targets[0], 115200, Parity.None, Target);

			Console.ReadLine();
			tempSerialManager.Close(temp);

			Console.ReadLine();
			SerialManager.SerialPortWithGuid temp2 = tempSerialManager.Add(targets[0], 115200, Parity.None, Target);
			temp2.Send("TEST");
			*/

			Console.ReadLine();
		}

		private static void Target(object sender, SerialDataReceivedEventArgs serialDataReceivedEventArgs)
		{
			SerialPort serial = (SerialPort) sender;

			Console.WriteLine(serial.ReadExisting());

		}
	}
}
