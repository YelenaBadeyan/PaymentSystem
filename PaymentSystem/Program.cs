using Microsoft.EntityFrameworkCore;
using PaymentSystem.Data.DBContext;
using PaymentSystem.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");


builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// Add services to the container.

//TODO Understand this line more deeply
builder.Services.AddTransient<UsersService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
