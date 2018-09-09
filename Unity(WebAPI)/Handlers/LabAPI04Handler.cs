using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Unity_WebAPI_.Handlers
{
    public class LabAPI04Handler : DelegatingHandler
    {
        string[] _methods = { "DELETE", "PUT", "PATCH"};
        const string _header = "X-HTTP-Method-Override";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, 
            CancellationToken cancellationToken)
        {
            if (request.Method == HttpMethod.Post && 
                request.Headers.Contains(_header))
            {
                var method = request.Headers.GetValues(_header)
                    .FirstOrDefault();
                if(_methods.Contains(method))
                {
                    request.Method = new HttpMethod(method);
                }
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}


