using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AutosysMonitor
{
    class AutosysSystemFileHandler
    {

        public static List<AutosysSystem> ReadFromFile(string Filename)
        {
            var systemer = File.OpenText(Filename);
            var systemList = new List<AutosysSystem>();

            while (!systemer.EndOfStream)
            {
                var line = systemer.ReadLine();
                if (line.First() == '#')
                    continue;
                var info = line.Split(';');
                var sys = new AutosysSystem();
                sys.Name = info[0];
                sys.URL = info[1];
                systemList.Add(sys);

            }
            systemer.Close();

            return systemList;
        }
    }
}
