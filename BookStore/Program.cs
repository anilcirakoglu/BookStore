

using BookStore.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Quartz.Impl;
using Quartz;
using BookStore.Jobs;
using BookStore.Business;
using FluentValidation.AspNetCore;
using BookStore.Business.Models;
using AutoMapper;
using Serilog;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using BookStore.Controllers;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.

Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

//--log
//var logger = new LoggerConfiguration()
//    .ReadFrom.Configuration(builder.Configuration)
//    .Enrich.FromLogContext()
//    .WriteTo.Console()
//    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)//günlük olarak yeni bir dosya oluþturacak
//    .CreateLogger();

//builder.Logging.ClearProviders();
//builder.Logging.AddSerilog(logger);

//--

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistanceServices();

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));

builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();
    var jobKey = new JobKey("DemoJob");
    q.AddJob<DemoJob>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity("DemoJob-trigger")
        .WithCronSchedule("0 * * ? * *"));

});

builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

//builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BooksCountByAuthorModel>());




var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

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
