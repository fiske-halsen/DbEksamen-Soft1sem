using ApiGateway.Service;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ApiService>();
builder.Services.AddScoped<IMircoserviceHandler, MicroserviceHandler>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<HelperService>();

var identityServer = configuration["IdentityServer:Host"];

builder.Services.AddAuthentication("token")
    .AddJwtBearer("token", options =>
    {
        // base-address of your identityserver
        options.Authority = identityServer;
        options.TokenValidationParameters.ValidateAudience = true;
        options.Audience = "GatewayServiceAPI"; // if you are using API resources, you can specify the name here
                                                // IdentityServer emits a typ header by default, recommended extra check
        options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
        options.RequireHttpsMetadata = false;
    });


builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.IgnoreObsoleteActions();
    c.IgnoreObsoleteProperties();
    c.CustomSchemaIds(type => type.FullName);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
