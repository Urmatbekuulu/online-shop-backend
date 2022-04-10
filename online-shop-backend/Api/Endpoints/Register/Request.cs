
using System.ComponentModel.DataAnnotations;

namespace online_shop_backend.Api.Endpoints.Register
{
    public class Request
    {
        public class Register
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