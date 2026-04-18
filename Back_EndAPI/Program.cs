using Microsoft.EntityFrameworkCore;
using Back_EndAPI.Data;
using Back_EndAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddScoped<ShipmentService>();
builder.Services.AddScoped<PurchaseOrderService>();
builder.Services.AddScoped<InventoryService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// EF Core + PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);



builder.Services.AddAuthorization();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();



app.MapControllers();

app.Run();
