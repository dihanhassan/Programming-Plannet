using BlogPost.Application.AppSettings;

namespace BlogPostWebApi.DependencyExtensions
{
    public static class RegisterSettings
    {
        public static void AddSettings(this WebApplicationBuilder builder)
        {
            var jwtSettings = new JWTSettings();
            //var mailSettings = new MailSettings();

            //builder.Configuration.Bind("MailSettings", mailSettings);
            builder.Configuration.Bind("Jwt", jwtSettings);

            //builder.Services.AddSingleton(mailSettings);
            builder.Services.AddSingleton(jwtSettings);
        }
    }
}
