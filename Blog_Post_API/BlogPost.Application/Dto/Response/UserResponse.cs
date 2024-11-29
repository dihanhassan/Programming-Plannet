using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Dto.Response
{
    public class UserResponse
    {
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Email { get; set; }
    }

    public class UserLoginResponse : UserResponse
    {
        public string Token { get; set; }
    }
}
