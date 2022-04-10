namespace online_shop_backend.Api.Endpoints.Register
{
    public class Response
    {
        public record IsRegistered(bool IsSuccess, string ErrorMessage = default);
    }
}