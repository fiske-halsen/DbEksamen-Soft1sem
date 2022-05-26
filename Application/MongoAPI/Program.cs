using MongoAPI;
using MongoAPI.Context;
using MongoAPI.ErrorHandling;
using MongoAPI.Services;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DbApplicationContext>(
    builder.Configuration.GetSection("OrderDatabase"));

builder.Services.AddControllers().AddNewtonsoftJson(options =>
                   options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

var identityServer = configuration["IdentityServer:Host"];


// Jwt tokens
builder.Services.AddAuthentication("token")
    .AddJwtBearer("token", options =>
    {
        // base-address of your identityserver
        options.Authority = identityServer;
        options.TokenValidationParameters.ValidateAudience = true;
        options.Audience = "MongoDBAPI"; // if you are using API resources, you can specify the name here
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

//-------------------------- Services for dependency injection ----------------//'
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

//Migration things that doesn't work yet
//DbApplicationContext appContext = new DbApplicationContext();
//appContext.Migration(builder.Configuration);

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
