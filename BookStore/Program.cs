using BookStore.Application.Repositories;
using BookStore.Persistence.Context;
using BookStore.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));

builder.Services.AddScoped<IBookReadRepository, BookReadRepository>();
builder.Services.AddScoped<IBookWriteRepository, BookWriteRepository>();

builder.Services.AddScoped<IPricesReadRepository, PricesReadRepository>();
builder.Services.AddScoped<IPricesWriteRepository, PricesWriteRepository>();

builder.Services.AddScoped<IUsersReadRepository, UsersReadRepository>();
builder.Services.AddScoped<IUsersWriteRepository, UsersWriteRepository>();


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
