using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using UserManagement.Application.Commands.Handlers;
using UserManagement.Application.Logics.Implementations;
using UserManagement.Application.Logics.Interfaces;
using UserManagement.Data.Context;
using UserManagement.Infrastructure.Context;
using UserManagement.Infrastructure.DBConnections.Implementations;
using UserManagement.Infrastructure.DBConnections.Interfaces;
using UserManagement.Shared.DOTs.RequestDTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi



builder.Services.AddDbContext<AuditDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuditDBConnection"))
);

builder.Services.AddDbContext<WriteAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WriteConnection")));


// Add Read DbContext (ReadAppDbContext)
builder.Services.AddDbContext<ReadAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReadConnection")));


builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WriteConnection")));



builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IUserLogics, UserLogics>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "User Management API",
        Version = "v1",
        Description = "API for managing users",
        Contact = new OpenApiContact
        {
            Name = "Ogidan Emmanuel",
            Email = "eogidan10@gmail.com",
            Url = new Uri("https://yourwebsite.com")
        }
    });
});


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly));


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "User Management API V1");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
