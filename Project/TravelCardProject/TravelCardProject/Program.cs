using Microsoft.EntityFrameworkCore;
using TravelCardProject.Entities;
using TravelCardProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TravelCardsDbContext>(opt =>
{
    var connString = builder.Configuration.GetConnectionString("TravelCardsDb");
    opt.UseNpgsql(connString);
});

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IPassangerService, PassengerService>();
builder.Services.AddScoped<ITariffService, TariffService>();
builder.Services.AddScoped<ITerminalService, TerminalService>();
builder.Services.AddScoped<ITravelCardService, TravelCardService>();
builder.Services.AddScoped<ITripService, TripService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
