using BlogPost.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Domain.Interfaces
{
    public interface IAuthRepository : IBaseRepository<User>
    {
        Task<User> userRegisterAsync(User userRegister);
        Task<User> userLoginAsync(String email);
        Task<User> UpdateUserByEmailAsync(User user);
    }
}
