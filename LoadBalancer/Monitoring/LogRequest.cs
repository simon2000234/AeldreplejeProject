using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LoadBalancer.Monitoring
{
	public class LogRequest
	{
	/*	[Write(false)]*/
		public Stopwatch Watch { get; set; } = new Stopwatch();

		public int StatusCode { get; set; }
		public string Method { get; set; }
		public string Path { get; set; }
		public string Body { get; set; }
		public string ResponseBody { get; set; }
        public string Host { get; set; }

		public long TimeMs
		{
			get
			{
				return Watch.ElapsedMilliseconds;
			}
		}

	}
}
