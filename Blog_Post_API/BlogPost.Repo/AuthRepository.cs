using BlogPost.Data;
using BlogPost.Domain.Entities;
using BlogPost.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Repo
{
    public class AuthRepository : BaseRepository<User>, IAuthRepository
    {
        private readonly EFDbContext _db;
        public AuthRepository(EFDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<User> userLoginAsync(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
        }



        public async Task<User> userRegisterAsync(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return user;
        }


        public async Task<User> UpdateUserByEmailAsync(User updatedUser)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == updatedUser.Email);

            user.Password = updatedUser.Password;

            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return user;
        }


    }
}
