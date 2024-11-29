using BlogPost.Application.Dto.Request;
using BlogPost.Application.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<UserLoginResponse> Login(LoginRequest loginRequest);

        #region Save
        Task<UserResponse> Register(UserRequest request);
        #endregion Save
    }
}
