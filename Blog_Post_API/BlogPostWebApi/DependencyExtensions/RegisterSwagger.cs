using Microsoft.OpenApi.Models;
using System.Reflection;

namespace BlogPostWebApi.DependencyExtensions
{
    public static class RegisterSwagger
    {
        public static void AddSwagger(this WebApplicationBuilder builder)
        {
            #region SeriLogger
            builder.Services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Blog-Post", Version = "v1" });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //opt.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
            #endregion SeriLogger
        }
    }
}
