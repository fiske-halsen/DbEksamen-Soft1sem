using IdentityServer.Context;
using IdentityServer.IdentityConfig;
using IdentityServer.Repository;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentityServer()
    .AddDeveloperSigningCredential()
    .AddInMemoryApiResources(IdentityConfiguration.ApiResources(configuration))
    .AddInMemoryApiScopes(IdentityConfiguration.ApiScopes)
    .AddInMemoryClients(IdentityConfiguration.Clients(configuration))
    .AddProfileService<ProfileService>()
    .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>();


builder.Services.AddDbContext<DbApplicationContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IDbConnection>((sp) => new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

builder.WebHost.UseUrls("https://localhost:5005");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true) // allow any origin
                                                        //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins separated with comma
                    .AllowCredentials()); // allow credentials

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseIdentityServer();

app.MapControllers();

app.Run();
