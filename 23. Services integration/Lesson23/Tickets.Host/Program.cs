using Microsoft.EntityFrameworkCore;
using Tickets.Application.Services;
using Tickets.Application.Services.Abstractions;
using Tickets.Integrations.Accounts;
using Tickets.Integrations.Clients;
using Tickets.Integrations.Tariffs;
using Tickets.Persistence.Postgres;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<TicketsDbContext>(opt =>
{
    var connString = builder.Configuration.GetConnectionString("TicketsDb");
    opt.UseNpgsql(connString);
});

var cnf = builder.Configuration;
builder.Services.AddHttpClient("clients",
    c => c.BaseAddress = new Uri(cnf.GetRequiredSection("ClientsServiceUrl").Value!));
builder.Services.AddHttpClient("accounts",
    c => c.BaseAddress = new Uri(cnf.GetRequiredSection("AccountsServiceUrl").Value!));
builder.Services.AddHttpClient("tariffs",
    c => c.BaseAddress = new Uri(cnf.GetRequiredSection("TariffsServiceUrl").Value!));

builder.Services.AddScoped<IClientsServiceClient, ClientsServiceClient>();
builder.Services.AddScoped<IAccountsServiceClient, AccountsServiceClient>();
builder.Services.AddScoped<ITariffsServiceClient, TariffsServiceClient>();
builder.Services.AddScoped<ITicketsService, TicketsService>();

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