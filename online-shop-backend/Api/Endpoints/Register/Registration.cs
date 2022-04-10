
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Asn1.Ocsp;

namespace online_shop_backend.Api.Endpoints.Register
{
    public class RegistrationEndpoint:EndpointBaseAsync.WithRequest<Request.Register>.WithResult<Response.IsRegistered>

    {
        public override Task<Response.IsRegistered> HandleAsync(Request.Register request, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }
    }
}