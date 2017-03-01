using EcapPipeline.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace EcapPipeline.Handler
{
    public class CustomHeaderHandler: DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
            //var myValue = response.GetFirstHeaderValueOrDefault<string>("UserName");

            IEnumerable<string> headerValues;

            if (request.Headers.TryGetValues("UserName", out headerValues))
            {
                StaticUser.UserName = headerValues.FirstOrDefault();
            }

            //HttpResponseMessage response = await base.SendAsync(request, cancellationToken);
            //response.Headers.Add("X-Custom-Header", "This is my custom header.");
            //return response;
            return base.SendAsync(request, cancellationToken);
        }
    }
}