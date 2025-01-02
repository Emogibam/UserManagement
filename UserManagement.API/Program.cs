using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using UserManagement.Data.Context;
using UserManagement.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi



builder.Services.AddDbContext<AuditDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuditDBConnection"))
);

builder.Services.AddDbContext<ReadAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReadConnection")));

builder.Services.AddDbContext<WriteAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WriteConnection")));


var app = builder.Build();

app.UseSwagger(); 
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
