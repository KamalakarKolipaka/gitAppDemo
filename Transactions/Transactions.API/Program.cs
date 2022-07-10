using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;
using Transactions.API;
using Transactions.Core.Interfaces;
using Transactions.Core.TransactionsMediator.Commands;
using Transactions.Infrastructure;
using Transactions.Infrastructure.Repositories;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDBContext>(Options =>
        Options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddScoped<ITransactionsRepository, TransactionsRepository>();
builder.Services.AddMediatR(typeof(CreateTransactions).GetTypeInfo().Assembly);

//Serilog
var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddScoped<ExceptionFilter>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(
      name: "AllowAll",
      builder => {
          builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
      });
});

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

app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
