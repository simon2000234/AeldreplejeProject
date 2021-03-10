using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LoadBalancer.Monitoring
{
    public class LogRepository
    {
        public void Insert(LogRequest item )
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                LogToFile(item);
            }
        }

        private void LogToFile( LogRequest l)
        {
            TextWriter w = new StreamWriter("log.txt");

            w.Write("\r\nLog Entry : ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine("  :"); 
            w.WriteLine($"  :{l.TimeMs.ToString()}");
            w.WriteLine($"  :{l.Path.ToString()}");
            w.WriteLine($"  :{l.ToString()}");
            w.WriteLine("-------------------------------");
        }
    }
}
