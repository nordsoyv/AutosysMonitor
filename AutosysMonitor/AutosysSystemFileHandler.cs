using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AutosysMonitor
{
	class AutosysSystemFileHandler
	{

		public static List<IAutosysSystem> ReadFromFile(string filename)
		{
			var systemer = File.OpenText(filename);
			var systemList = new List<IAutosysSystem>();

			while (!systemer.EndOfStream)
			{
				var line = systemer.ReadLine();
				if (line.First() == '#')
					continue;
				if (line.First() == '-')
				{
					systemList.Add(CreateSplitter(line));
				}
				else
				{
					systemList.Add(CreateAutosysSystem(line));
				}

			}
			systemer.Close();

			return systemList;
		}

		private static IAutosysSystem CreateSplitter(string line)
		{
			var info = line.Split(';');
			var sys = new LineSplitter();
			sys.Name = info[0].Substring(1);
			sys.Url = "--------------";
			return sys;
		}

		private static IAutosysSystem CreateAutosysSystem(String line)
		{
			var info = line.Split(';');
			var sys = new AutosysSystem();
			sys.Name = info[0];
			sys.Url = info[1];

			try
			{
				sys.Timeout = int.Parse(info[2]);
			}
			catch (Exception)
			{
				sys.Timeout = 2000;
			}
			return sys;
		}
	}
}
