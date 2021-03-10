using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LoadBalancer
{
    public class LoadBalancer
    {
        private static LoadBalancer _instance;
        private Queue<string> hosts;

        private LoadBalancer()
        {
            hosts = new Queue<string>();
        }

        public static LoadBalancer GetInstance()
        {
            return _instance ??= new LoadBalancer();
        }

        public string GetHost()
        {
            var host = hosts.Dequeue();
            hosts.Enqueue(host);
            return host;
        }


    }
}