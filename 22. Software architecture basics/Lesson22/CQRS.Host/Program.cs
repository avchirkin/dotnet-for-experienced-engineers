using CQRS.Features.Accounts.CreateAccount;
using CQRS.Features.Clients.CreateClient;
using CQRS.Features.Tariffs.CreateTariff;
using CQRS.Features.Tickets.CreateTicket;
using CQRS.Persistence.Postgres;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<AutoTicketDbContext>(opt =>
{
    var connString = builder.Configuration.GetConnectionString("AutoTicketsDb");
    opt.UseNpgsql(connString);
});

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        typeof(CreateAccountHandler).Assembly,
        typeof(CreateClientHandler).Assembly,
        typeof(CreateTariffHandler).Assembly,
        typeof(CreateTicketHandler).Assembly
        );
});

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