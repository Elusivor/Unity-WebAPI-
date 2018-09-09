using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Unity_WebAPI_.Handlers
{
    public class FullPipelineTimerHandler : DelegatingHandler
    {
        const string _header = "X-API-Timer";
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //Before
            var timer = Stopwatch.StartNew();
            //Pipeline
            var response = await base.SendAsync(request, cancellationToken);
            //After
            var elapsed = timer.Elapsed;

            Trace.Write($"___API Pipeline took: {elapsed}");
            response.Headers.Add(_header, $"{elapsed} msec");
            //Send
            return response;
        }
    }
}