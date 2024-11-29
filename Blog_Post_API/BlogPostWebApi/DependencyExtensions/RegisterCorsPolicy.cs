namespace BlogPostWebApi.DependencyExtensions
{
    public static class RegisterCorsPolicy
    {
        public static void AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "CorsPolicy", policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithExposedHeaders("X-Pagination");
                });
            });
        }
    }
}
