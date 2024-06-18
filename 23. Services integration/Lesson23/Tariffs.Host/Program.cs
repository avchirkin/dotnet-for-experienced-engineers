using Microsoft.EntityFrameworkCore;
using Tariffs.Application.Services;
using Tariffs.Application.Services.Abstractions;
using Tariffs.Persistence.Postgres;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<TariffsDbContext>(opt =>
{
    var connString = builder.Configuration.GetConnectionString("TariffsDb");
    opt.UseNpgsql(connString);
});

builder.Services.AddScoped<ITariffsService, TariffsService>();

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