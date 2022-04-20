using System.Reflection;
using Gladiator.Application.Gladiator.CommandHandlers;
using Gladiator.Core.Repositories;
using Gladiator.Core.Repositories.Base;
using Gladiator.Infrastructure.Data.Data;
using Gladiator.Infrastructure.Data.Repositories;
using Gladiator.Infrastructure.Data.Repositories.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(
    x => x.SerializerSettings.ReferenceLoopHandling 
        = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddDbContext<GladiatorContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("GladiatorDatabase")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddMediatR(typeof(CreateGladiatorHandler).GetTypeInfo().Assembly);
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IGladiatorRepository, GladiatorRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
