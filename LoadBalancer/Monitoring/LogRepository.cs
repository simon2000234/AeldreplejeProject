using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LoadBalancer.Monitoring
{
    public class LogRepository
    {
        public void Insert(LogRequest item)
        {
            
            LogToFile(item);

        }

        private void LogToFile(LogRequest l)
        {
            var file = new FileInfo("log.txt");
            bool locked = true;
            while (locked)
            {
                locked = IsFileLocked(file);
            }

            var stream = File.AppendText("log.txt");
            TextWriter w = stream;
            
            w.Write("\r\nLog Entry : ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine("  :");
            w.WriteLine($"  :How long in ms to get response {l.TimeMs.ToString()}");
            w.WriteLine($"  :The call used {l.Path.ToString()}");
            w.WriteLine($"  :The host the load balancer sends it to {l.Host.ToString()}");
            w.WriteLine("-------------------------------");
            w.Close();
            w.Dispose();
            stream.Close();
            stream.Dispose();
        }

        protected virtual bool IsFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }

            //file is not locked
            return false;
        }
    }
}
