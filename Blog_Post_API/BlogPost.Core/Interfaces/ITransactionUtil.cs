using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Domain.Interfaces
{
    public interface ITransactionUtil : IDisposable
    {
        Task BeginAsync();
        Task CommitAsync();
        Task RollBackAsync();
    }
}
