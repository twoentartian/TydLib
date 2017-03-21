using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThreadManagerNamespace;

namespace Main
{
	class Program
	{
		static void Main(string[] args)
		{
			const int LENGTH = 10;

			ThreadManager tempManager = ThreadManager.GetInstance();
			Guid[] tempGuids = new Guid[LENGTH];
			TimerCallback tc = new TimerCallback(print);
			for (int i = 0; i < LENGTH; i++)
			{
				tempGuids[i] = tempManager.AddThread(tc, i, 0, 5000);
			}

			Console.ReadLine();

			for (int i = 0; i < LENGTH; i++)
			{
				tempManager.StopThread(tempGuids[i]);
			}
			Console.ReadLine();
		}

		static void print(object state)
		{
			Console.WriteLine(state);
		}
	}
}
