using BlogPost.Domain.Interfaces;
using BlogPost.Repo;

namespace BlogPostWebApi.DependencyExtensions
{
    public static class RegisterRepository
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();
        }
    }
}
