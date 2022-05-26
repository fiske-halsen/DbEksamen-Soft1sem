using IdentityServer4.AccessTokenValidation;
using Ocelot.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
var configuration = builder.Configuration;

var identityBuilder = builder.Services.AddAuthentication();
identityBuilder.AddIdentityServerAuthentication("CatalogAPIKey", options =>
{
    options.Authority = "{IDM_SERVER_URL}";
    options.RequireHttpsMetadata = false;
    options.ApiName = "{RESOURCE_API_NAME}";
    options.ApiSecret = "{RESOIRCE_API_Secret}";
    options.SupportedTokens = SupportedTokens.Jwt;
});
identityBuilder.AddIdentityServerAuthentication("CatalogAPIKey", options =>
{
    options.Authority = "{IDM_SERVER_URL}";
    options.RequireHttpsMetadata = false;
    options.ApiName = "{RESOURCE_API_NAME}";
    options.ApiSecret = "{RESOIRCE_API_Secret}";
    options.SupportedTokens = SupportedTokens.Jwt;
});
identityBuilder.AddIdentityServerAuthentication("CatalogAPIKey", options =>
{
    options.Authority = "{IDM_SERVER_URL}";
    options.RequireHttpsMetadata = false;
    options.ApiName = "{RESOURCE_API_NAME}";
    options.ApiSecret = "{RESOIRCE_API_Secret}";
    options.SupportedTokens = SupportedTokens.Jwt;
});

builder.Services.AddOcelot(builder.Configuration);




var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
