using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Dto.Request
{
    public class UserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(256)]
        public string Password
        {
            get
            {
                return BCrypt.Net.BCrypt.HashPassword(_password);
            }
            set
            {
                _password = value;
            }
        }

        private string _password { get; set; }
    }
}
