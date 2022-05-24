using MongoAPI;
using MongoAPI.Context;
using MongoAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DbApplicationContext>(
    builder.Configuration.GetSection("OrderDatabase"));

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

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
