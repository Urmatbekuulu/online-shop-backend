using System.ComponentModel.DataAnnotations;

namespace online_shop_backend.Api.Endpoints.Authorize
{
    public class Request
    {
        public class Input
        {
            [Required]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}
