

using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;

namespace online_shop_backend.Api.Endpoints.Authorize
{
    public class Login:EndpointBaseAsync.WithRequest<Request.Input>.WithResult<Response.Result>
    {
        public override Task<Response.Result> HandleAsync(Request.Input request, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }
    }
}