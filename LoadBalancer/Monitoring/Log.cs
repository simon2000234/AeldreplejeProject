using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoadBalancer.Monitoring
{
    public class Log
    {
        private LogRepository repo;

        public Log(LogRepository repo)
        {
            this.repo = repo;
        }

        public LogRequest StartRequest()
        {
            var request = new LogRequest();
            request.Watch.Start();
            return request;
        }

        public void  StopRequest(LogRequest request)
        {
            request.Watch.Stop();

            if (this.RecordInDatabase(request))
            {
                 repo.Insert(request);
            }
        }

        private bool RecordInDatabase(LogRequest request)
        {

            return true;
        }
    }
}