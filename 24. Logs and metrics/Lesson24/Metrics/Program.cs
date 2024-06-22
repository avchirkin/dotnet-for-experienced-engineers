using Metrics.HealthChecks;
using Metrics.Services;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductsService, ProductsService>();

builder.Services.UseHttpClientMetrics();
builder.Services.AddHealthChecks()
    .AddCheck<SimpleHealthCheck>(nameof(SimpleHealthCheck))
    .ForwardToPrometheus();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpMetrics();

app.MapMetrics();

app.MapControllers();
app.UseRouting();
app.UseHttpsRedirection();

app.Run();