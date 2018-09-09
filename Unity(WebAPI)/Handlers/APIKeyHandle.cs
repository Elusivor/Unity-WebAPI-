using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Unity_WebAPI_.Handlers
{
    public class APIKeyHandle : DelegatingHandler
    {
        const string APIHeaderName = "KeyHandler";
        const string APIQueryName = "api_key";
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //Before
            string apikeyInRequest = null;

            if(request.RequestUri.Segments[1].ToLowerInvariant().StartsWith("swagger"))
            {
                return await base.SendAsync(request, cancellationToken);
            }
            if (request.Headers.Contains(APIHeaderName))
            {
                apikeyInRequest = request.Headers.GetValues(APIHeaderName).FirstOrDefault();
            }
            else
            {
                var queryValuePairs = request.GetQueryNameValuePairs();

                var singleValuePairs = queryValuePairs.FirstOrDefault(k => k.Key.ToLowerInvariant().Equals(APIQueryName));
                if (!string.IsNullOrEmpty(singleValuePairs.Value))
                {
                    apikeyInRequest = singleValuePairs.Value;
                }
            }

            if (string.IsNullOrEmpty(apikeyInRequest))
            {
                var responseErr = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                {
                    Content = new StringContent("Missing API Key")
                };
                return await Task.FromResult(responseErr);
            }
            else
            {
                request.Properties.Add(APIQueryName, apikeyInRequest);
            }
            //Pipeline
            var response = await base.SendAsync(request, cancellationToken);
            //After

            //Return
            return response;
        }
    }
}