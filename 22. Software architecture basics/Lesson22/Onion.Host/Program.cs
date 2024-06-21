using Microsoft.EntityFrameworkCore;
using Onion.Application.Services;
using Onion.Application.Services.Abstractions;
using Onion.Persistence.Postgres;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<AutoTicketDbContext>(opt =>
{
    var connString = builder.Configuration.GetConnectionString("AutoTicketsDb");
    opt.UseNpgsql(connString);
});

builder.Services.AddScoped<IClientsService, ClientsService>();
builder.Services.AddScoped<IAccountsService, AccountsService>();
builder.Services.AddScoped<ITariffsService, TariffsService>();
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