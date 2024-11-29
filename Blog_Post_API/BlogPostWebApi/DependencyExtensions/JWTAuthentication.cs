using BlogPost.Application.AppSettings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BlogPostWebApi.DependencyExtensions
{
    public static class JWTAuthentication
    {
        public static void AddJWTAuthentication(this WebApplicationBuilder builder)
        {
            var jwtSettings = new JWTSettings();
            builder.Configuration.Bind("Jwt", jwtSettings);
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidIssuer = jwtSettings.Issuer,
                            ValidAudience = jwtSettings.Audience,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                        };
                    });
        }
    }
}
