using Accounts.Application.Services;
using Accounts.Application.Services.Abstractions;
using Accounts.Persistence.Postgres;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<AccountsDbContext>(opt =>
{
    var connString = builder.Configuration.GetConnectionString("AccountsDb");
    opt.UseNpgsql(connString);
});

builder.Services.AddScoped<IAccountsService, AccountsService>();

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