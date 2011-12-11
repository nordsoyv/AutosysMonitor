using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;

namespace AutosysMonitor
{
    class AutosysSystem : IAutosysSystem
    {
        public String Name { get; set; }
        public String Url { get; set; }
        public int Timeout { get; set; }
        public bool Alive { get; set; }
        public long Ping { get; set; }
    	public void Update()
    	{

			var request = WebRequest.Create(Url);
			request.Timeout = Timeout;
			WebResponse response;
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			try
			{
				response = request.GetResponse();
				Alive = true;
			}
			catch (WebException ex)
			{
				Alive = false;
				return;
			}
			finally
			{
				stopwatch.Stop();
				Ping = stopwatch.ElapsedMilliseconds; 
				request.Abort();
			}

    	}

   

    }
}
