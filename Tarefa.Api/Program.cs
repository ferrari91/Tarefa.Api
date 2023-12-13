using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Tarefa.Application;
using Tarefa.Application.Features.Task.Create;
using Tarefa.Infrastructure.DataBase;
using Tarefa.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationLayer(builder.Configuration);
builder.Services.ConfigureDataBase(builder.Configuration);
builder.Services.ConfigureResporitories();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    await services.GetRequiredService<DataContext>().Database.EnsureCreatedAsync();
    await services.GetRequiredService<DataContext>().Database.MigrateAsync();
}

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
