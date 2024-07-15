using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MinimalAPI.Data;
using MinimalAPI.Entities;
using MinimalAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// add services to DI container

//sqlite
builder.Services.AddDbContext<DbContext, SQLiteDbContext>();

builder.Services.AddScoped<RuleCarProductionService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RuleCarProduction Minimal API", Version = "v1" });
});

builder.Services.AddCors();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection(); // force use https. comment to use postman or File > Settings > Off the SSL certificate verification in General Tab

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Rule Car Production Minimal API");
    options.RoutePrefix = string.Empty; //"swagger/ui"; //string.Empty; // to arrest the root page use string.Empty
                                       // clear browser cache anytime this value is cahange
});

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

//app.MapGet("/", () => "Hello World!");

// Get all
app.MapGet("/rulecarproductions", async (RuleCarProductionService s) =>
{
    return await s.GetProductsAsync();
});

// Get
app.MapGet("/rulecarproductions/{id}", async (int id, RuleCarProductionService s) =>
{
    return await s.GetProductAsync(id);
});

// Create
app.MapPost("/rulecarproductions", async (RuleCarProduction model, RuleCarProductionService s) =>
{
    return await s.AddProductAsync(model);
});

// Update
app.MapPut("/rulecarproductions/{id}", async (RuleCarProduction model, RuleCarProductionService s) =>
{
    return await s.UpdateProduct(model);
});

// Delete
app.MapDelete("/rulecarproductions/{id}", async (int id, RuleCarProductionService s) =>
{
    return await s.DeleteProductAsync(id);
});

// Calculate
app.MapPost("/calculateproduct", async (List<RuleCarProduction> model, RuleCarProductionService s) =>
{
    return await s.CalculateProductAsync(model);
});

// Get all transaction
app.MapGet("/transactioncarproductions", async (RuleCarProductionService s) =>
{
    return await s.GetTransactionCarProductionAsync();
});
app.Run();
