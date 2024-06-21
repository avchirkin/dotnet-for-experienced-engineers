using Logging.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IProductsService, ProductsService>();

// Добавляем логирование. Используем стандартное логирование Microsoft.Extensions.Logging и надстройку
// Seq.Extensions.Logging, адаптирующую логи к формату, понятному Seq
builder.Services.AddLogging(b => b.AddSeq(builder.Configuration.GetSection("Seq")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseRouting();
app.UseHttpsRedirection();

app.Run();