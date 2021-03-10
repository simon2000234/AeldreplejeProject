using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LoadBalancer.Monitoring
{
    public class MiddlewareRequestLog
    {
        private readonly RequestDelegate next;

        public MiddlewareRequestLog(RequestDelegate next)
        {
            this.next = next;

        }

        public async Task Invoke(HttpContext context, Log log)
        {
            if (log is null)
            {
                throw new ArgumentNullException(nameof(log));
            }

            //request

            LogRequest request = log.StartRequest();
            request.Path = context.Request.Path;
            // streamble more than once
            context.Request.EnableBuffering();
            request.Body = await new StreamReader(context.Request.Body).ReadToEndAsync();
            //read again later
            context.Request.Body.Position = 0;

            request.Method = context.Request.Method;

            var claims = context.User.Claims;
            //finds claimtype 

            var origionalStream = context.Response.Body;

            var bodyBuffer = new MemoryStream();
            context.Response.Body = bodyBuffer;

            await next(context);

            // response

            if (context.Response != null)
                request.StatusCode = context.Response.StatusCode;
            else request.StatusCode = 0;

            bodyBuffer.Seek(0, SeekOrigin.Begin);
            var stream = context.Response.Body;
            request.ResponseBody = await new StreamReader(stream).ReadToEndAsync();

            bodyBuffer.Seek(0, SeekOrigin.Begin);
            await bodyBuffer.CopyToAsync(origionalStream);
            context.Response.Body = origionalStream;

            //ends 
             log.StopRequest(request);
        }
    }
}
