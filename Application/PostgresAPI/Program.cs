using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PostgresAPI.Context;
using PostgresAPI.Repository;
using PostgresAPI.Services;
using RestaurantMicroservice.ErrorHandling;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(swagger =>
{
    //This is to generate the Default UI of Swagger Documentation
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ASP.NET 5 Web API",
        Description = "Authentication and Authorization with Swagger"
    });
    // To Enable authorization using Swagger (JWT)
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
    //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //swagger.IncludeXmlComments(xmlPath);
});

builder.Services.AddControllers().AddNewtonsoftJson(options =>
                   options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


  builder.Services.AddHttpContextAccessor();


  builder.Services.AddDbContext<DbApplicationContext>(options =>
              options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));


  var identityServer = configuration["IdentityServer:Host"];

  // Jwt tokens
  builder.Services.AddAuthentication("token")
      .AddJwtBearer("token", options =>
      {
        // base-address of your identityserver
        options.Authority = identityServer;
          options.TokenValidationParameters.ValidateAudience = true;
          options.Audience = "RestaurantServiceAPI"; // if you are using API resources, you can specify the name here
                                                     // IdentityServer emits a typ header by default, recommended extra check
        options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
          options.RequireHttpsMetadata = false;
        // if token does not contain a dot, it is a reference token
        //options.ForwardDefaultSelector = Selector.ForwardReferenceToken("introspection");
    });
  //// Reference Tokens
  //.AddOAuth2Introspection("introspection", options =>
  //{
  //    options.Authority = "https://localhost:44347";
  //    options.ClientId = "web-api";
  //    options.ClientSecret = configuration["IdentityServer:Key"];
  //});

  builder.Services.AddAuthorization();

  // ------------------ Services for dependency injection ------------------------------
  builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
  builder.Services.AddScoped<IRestaurantService, RestaurantService>();
  builder.Services.AddScoped<IUserRepository, UserRepository>();
  builder.Services.AddScoped<IUserService, UserService>();



var app = builder.Build();


  // Configure the HTTP request pipeline.
  if (app.Environment.IsDevelopment())
  {
      app.UseSwagger();
      app.UseSwaggerUI();
  }

  app.ConfigureExceptionHandler();
  app.UseHttpsRedirection();
  app.UseAuthentication();
  app.UseAuthorization();
  app.MapControllers();

  app.Run();
