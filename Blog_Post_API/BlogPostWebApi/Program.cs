using BlogPost.Data.Setups;
using BlogPostWebApi.DependencyExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
#region Dependency Injection for entity framework core implementation (Infrastructure)
string? connectionString = builder.Configuration.GetValue<string>("DbSettings:DbConnectionString");
builder.Services.AddPersistence(connectionString);
#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.AddSettings();
builder.AddJWTAuthentication();
builder.AddSwagger();
builder.Services.AddCorsPolicy();
builder.Services.AddServices();
builder.Services.AddRepositories();
// add mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddAutoMapper(typeof(DefaultProfile), typeof(RequestMapper), typeof(ResponseMapper));
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
