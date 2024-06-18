using Clients.Application.Services;
using Clients.Application.Services.Abstractions;
using Clients.Persistence.Postgres;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<ClientsDbContext>(opt =>
{
    var connString = builder.Configuration.GetConnectionString("ClientsDb");
    opt.UseNpgsql(connString);
});

builder.Services.AddScoped<IClientsService, ClientsService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();
app.UseRouting();

app.Run();