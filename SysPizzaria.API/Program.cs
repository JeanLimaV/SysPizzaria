using Microsoft.EntityFrameworkCore;
using SysPizzaria.Infra.Data.Context;
using SysPizzaria.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddControllers();

builder
    .Services
    .AddEndpointsApiExplorer();

builder
    .Services
    .AddSwaggerGen();

builder
    .Services.
    ConfigureApplication(builder.Configuration);

builder
    .Services    
    .AddServices();
    
builder
    .Services
    .CreateAutoMapper();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();