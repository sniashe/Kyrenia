using Kyrenia.Application;
using Kyrenia.Application.Providers;
using Kyrenia.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<TitleProviderOptions>(
    builder.Configuration.GetSection(TitleProviderOptions.SectionName));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

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
