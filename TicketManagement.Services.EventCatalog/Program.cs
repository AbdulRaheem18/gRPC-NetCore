
using EventCatalog.gRPC;
using FOD.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using TicketManagement.Services.EventCatalog.Application.Feature.Category.Queries;
using TicketManagement.Services.EventCatalog.Core.Repositories;
using TicketManagement.Services.EventCatalog.Infrastructure.Repositories;
using TicketManagement.Services.EventCatalog.Infrastructure.Repositories.Base;
using TicketManagement.Services.EventCatalog.RPCServices;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Database connection
var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddDbContext<DatabaseContext>(x => x.UseSqlServer(connectionString));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adding MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetAllCategoiresHandler>());

// Adding repository
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IEventRepository, EventRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

// adding grpc

builder.Services.AddGrpc(cfg => cfg.EnableDetailedErrors = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapGrpcService<EventCatalogRPCService>();

app.MapControllers();
app.Run("http://127.0.0.1:8080");

