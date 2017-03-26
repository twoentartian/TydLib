using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortNamespace
{
	public sealed class SerialManager
	{
		#region Singleton

		private static SerialManager _instance;

		private SerialManager()
		{

		}

		public static SerialManager GetInstance()
		{
			return _instance ?? (_instance = new SerialManager());
		}

		#endregion

		public delegate void ListenTaskDelegate(byte[] data);

		public static string[] GetAllPorts()
		{
			return SerialPort.GetPortNames();
		}

		public class SerialPortWithGuid
		{
			public SerialPortWithGuid()
			{
				Guid = Guid.Empty;
				Serial = null;
				Occupied = false;
			}

			public Guid Guid;
			public SerialPort Serial;
			public bool Occupied;

			/// <summary>
			/// Read vaild data
			/// </summary>
			/// <returns></returns>
			public byte[] Read()
			{
				int length = Serial.BytesToRead;
				byte[] data = new byte[length];
				Serial.Read(data, 0, length);
				return data;
			}
		}

		private SerialPortWithGuid[] _serialPortArray = new SerialPortWithGuid[5];

		/// <summary>
		/// Get the free port. (Not occupied)
		/// </summary>
		/// <returns></returns>
		private SerialPortWithGuid GetFreePort()
		{
			foreach (var port in _serialPortArray)
			{
				if (port.Occupied == false)
				{
					return port;
				}
			}
			throw new NotEnoughPortArrayException("Please add port array length in library");
		}

		/// <summary>
		/// Get port according to port GUID.
		/// </summary>
		/// <param name="argGuid"></param>
		/// <returns></returns>
		public SerialPortWithGuid GetPort(Guid argGuid)
		{
			foreach (var port in _serialPortArray)
			{
				if (port.Guid == argGuid)
				{
					return port;
				}
			}
			throw new ArgumentException("Cannot find vaild port with GUID: " + argGuid);
		}

		/// <summary>
		/// Find port according to port name.
		/// </summary>
		/// <param name="argPortName"></param>
		/// <returns></returns>
		public SerialPortWithGuid GetPort(string argPortName)
		{
			foreach (var port in _serialPortArray)
			{
				if (port.Occupied)
				{
					if (port.Serial.PortName == argPortName)
					{
						return port;
					}
				}
			}
			throw new ArgumentException("Cannot find vaild port with name: " + argPortName);
		}

		/// <summary>
		/// Occupy a port and use it to communicate.
		/// </summary>
		/// <param name="argPortName"></param>
		/// <param name="argBaudRate"></param>
		/// <param name="argParity"></param>
		/// <returns></returns>
		public SerialPortWithGuid Add(string argPortName, int argBaudRate, Parity argParity, SerialDataReceivedEventHandler argHandler)
		{
			SerialPortWithGuid tempSerialPortWithGuid = GetFreePort();
			tempSerialPortWithGuid.Occupied = true;
			tempSerialPortWithGuid.Guid = Guid.NewGuid();
			tempSerialPortWithGuid.Serial = new SerialPort(argPortName, argBaudRate, argParity);
			tempSerialPortWithGuid.Serial.Open();
			tempSerialPortWithGuid.Serial.DataReceived += argHandler;
			return tempSerialPortWithGuid;
		}

	}
}
