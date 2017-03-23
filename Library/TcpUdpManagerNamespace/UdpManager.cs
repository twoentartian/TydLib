using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpUdpManagerNamespace
{
	public sealed class UdpManager
	{
		#region Singleton

		private static UdpManager _instance;

		private UdpManager()
		{
			
		}

		public static UdpManager GetInstance()
		{
			return _instance ?? (_instance = new UdpManager());
		}

		#endregion

		private void Print(string info)
		{
			Console.WriteLine("UDP Manager: " + info);
		}

		#region Property

		private string _hostName;
		public string HostName => _hostName;

		private IPAddress _hostIpAddress;
		public IPAddress HostIpAddress => _hostIpAddress;

		private IPEndPoint _hostIpEndPoint;
		public IPEndPoint HostIpEndPoint => _hostIpEndPoint;

		private UdpClient _hostUdpClient;
		public UdpClient HostUdpClient => _hostUdpClient;

		#endregion

		public void Init(int argPort)
		{
			_hostName = null;
			_hostIpAddress = null;
			_hostIpEndPoint = null;
			_hostUdpClient = null;

			_hostName = Dns.GetHostName();
			IPAddress[] allAddresses = Dns.GetHostAddresses(_hostName);
			IEnumerable<IPAddress> ipV4AddressList = from singleAddresses in allAddresses where (singleAddresses.AddressFamily == AddressFamily.InterNetwork) select singleAddresses;
			IPAddress[] ipV4AddressArray = ipV4AddressList.ToArray();
			if (ipV4AddressArray.Length == 0)
			{
				throw new NoVaildIpV4AddressException("No Vaild InterNetwork V4 Address");
			}
			else if (ipV4AddressArray.Length == 1)
			{
				_hostIpAddress = ipV4AddressArray[0];
			}
			else
			{
				throw new MultiIpV4AddressException("More Than One Vaild InterNetwork V4 Address");
			}

			_hostIpEndPoint = new IPEndPoint(_hostIpAddress, argPort);
			_hostUdpClient = new UdpClient(_hostIpEndPoint);

			//Add listen thread
			Thread listenThread = new Thread(Listen) {IsBackground = true};
			listenThread.Start();

			Print("Start listening");
		}

		private void Listen()
		{
			while (true)
			{
				IPEndPoint remotEndPoint = new IPEndPoint(IPAddress.Any, 0);
				byte[] data = _hostUdpClient.Receive(ref remotEndPoint);

				//TODO: add code for listening
				Print(remotEndPoint.Address + ": " + Encoding.ASCII.GetString(data));
			}
		}

		public void Send(IPAddress remoteIpAddress, int port, string message)
		{
			if (_hostName == null || _hostIpAddress == null || _hostIpEndPoint == null || _hostUdpClient ==null)
			{
				throw new UdpManagerNotInitializeException("Please init UdpManager first");
			}
			byte[] data = Encoding.ASCII.GetBytes(message);
			_hostUdpClient.Send(data, data.Length, new IPEndPoint(remoteIpAddress, port));
		}

	}
	
}
