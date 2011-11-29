using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutosysMonitor
{
    class AutosysSystem
    {
        public String Name { get; set; }
        public String URL { get; set; }
        public bool Alive { get; set; }
        public long Ping { get; set; }

        
    }
}
