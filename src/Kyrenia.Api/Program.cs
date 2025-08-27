using Kyrenia.Api.Configuration;
using Kyrenia.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<OmdbOptions>(
    builder.Configuration.GetSection(OmdbOptions.SectionName));

builder.Services.AddHttpClient<IOmdbService, OmdbService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseExceptionHandler("/error");

app.MapControllers();

app.Run();
