using System;

namespace AutosysMonitor
{
	internal interface IAutosysSystem
	{
		String Name { get; set; }
		String Url { get; set; }
		int Timeout { get; set; }
		bool Alive { get; set; }
		long Ping { get; set; }
        String Tags { get; set; }
		void Update();
	}

	class LineSplitter : IAutosysSystem
	{
		public String Name { get; set; }
		public String Url { get; set; }
		public int Timeout { get; set; }
		public bool Alive { get; set; }
		public long Ping { get; set; }
        public String Tags { get; set; }

		public void Update()
		{
			return;
		}
	}
}