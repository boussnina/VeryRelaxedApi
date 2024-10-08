using Microsoft.EntityFrameworkCore;
using VeryRelaxedApi.BusinessLogic;
using VeryRelaxedApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// 1. Add your DbContext service here (example using SQL Server)
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPlayerBusinessLogic, PlayerBusinessLogic>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();

builder.Services.AddScoped<ICoachBusinessLogic, CoachBusinessLogic>();
builder.Services.AddScoped<ICoachRepository, CoachRepository>();


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
