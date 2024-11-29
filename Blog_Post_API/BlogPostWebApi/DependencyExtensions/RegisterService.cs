using BlogPost.Application.Interfaces.Auth;
using BlogPost.Data.Setups;
using BlogPost.Domain.Interfaces;
using BlogPost.Service;

namespace BlogPostWebApi.DependencyExtensions
{
    public static class RegisterService
    {
        public static void AddServices(this IServiceCollection services)
        {
            #region A
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITransactionUtil,TransactionUtil>();
            #endregion A
        }
    }
}
