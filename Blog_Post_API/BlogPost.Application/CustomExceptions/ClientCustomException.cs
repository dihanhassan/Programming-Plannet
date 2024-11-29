using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.CustomExceptions
{
    public class ClientCustomException : Exception
    {
        private readonly Dictionary<string, object> _errorData;

        public ClientCustomException(
            string message,
            Dictionary<string, object>? errorData = null
        ) : base(message)
        {
            _errorData = errorData ?? new Dictionary<string, object>();
        }

        public Dictionary<string, object> GetErrorData()
        {
            return _errorData;
        }
    }
}
