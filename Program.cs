using BrasilApiConsumer.Services;
using Refit;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services.AddRefitClient<IBrasilApi>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri("https://brasilapi.com.br/api");
    });

builder.Services.AddControllers();
builder.Services.Configure<RouteOptions>(o => o.LowercaseUrls = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
