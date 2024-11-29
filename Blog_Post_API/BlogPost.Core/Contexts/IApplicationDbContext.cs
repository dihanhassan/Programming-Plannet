using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogPost.Domain.Entities;

namespace BlogPost.Domain.Contexts
{
    public interface IApplicationDbContext : IInfrastructure<IServiceProvider>
    {
        DatabaseFacade Database { get; }

        #region DbSets
        DbSet<User> Users { get; set; }
    /*    DbSet<Category> Categories { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<PostCategory> PostCategories { get; set; }*/

        #endregion DbSets

        #region Methods
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        void Dispose();
        #endregion
    }
}
