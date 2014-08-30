using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

//Application grabs the lastest performance counters and displays them in a cmd window

namespace Perfmon
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//change the background color and the foreground color
			#region BackgroundColorChange
			Console.BackgroundColor = ConsoleColor.DarkBlue;
			#endregion
			#region ForegroundColorChange
			Console.ForegroundColor = ConsoleColor.DarkMagenta;
			#endregion
			#region WriteIntroductiontoConsole
			Console.WriteLine ("Welcome to Test App");
			Console.WriteLine ("This program is (C) Jack Sullivan");
			#endregion
			#region GrabPerformanceCounters
			//This will pull the current cpu load in a percentage
			PerformanceCounter perfCpuCount = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
			perfCpuCount.NextValue();
			// This will pull the current available memory in Megabytes
			PerformanceCounter perfMemCount = new PerformanceCounter("Memory", "Available MBytes");
			perfMemCount.NextValue();
			// This will get us the system uptime (in seconds)
			PerformanceCounter perfUptimeCount = new PerformanceCounter("System", "System Up Time");
			perfUptimeCount.NextValue();
			#endregion
			#region Infinite While Loop
			// Infinite While Loop that prints the current cpu load and the current memory usage
			while (true) {
				// Get the current performance counter values
				int currentCpuPercentage = (int)perfCpuCount.NextValue ();
				int currentAvailableMemory = (int)perfMemCount.NextValue ();

				// Every 1 second print the CPU load in percentage to the screen
				Console.WriteLine ("CPU Load        : {0}%", currentCpuPercentage);
				Console.WriteLine ("Available Memory: {0}", currentAvailableMemory);
				Thread.Sleep(1000);
			}
			#endregion
		}

	}

}
