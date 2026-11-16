using CustomerWebApi.Data;
using CustomerWebApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Enable Aspire OpenTelemetry, health checks, and service discovery
builder.AddServiceDefaults();

// Register SQL Server DbContext using the AppHost resource name
builder.AddSqlServerDbContext<CustomerDbContext>("customerdb");

builder.Services.AddOpenApi();

var app = builder.Build();

// Automatically create the database and apply migrations on container startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CustomerDbContext>();
    await db.Database.MigrateAsync();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Customer Microservice Endpoints
var customers = app.MapGroup("/api/customers");

customers.MapGet("/", async (CustomerDbContext db) =>
    await db.Customers.ToListAsync());

customers.MapGet("/{id:guid}", async (Guid id, CustomerDbContext db) =>
    await db.Customers.FindAsync(id) is Customer customer
        ? Results.Ok(customer)
        : Results.NotFound());

customers.MapPost("/", async (Customer customer, CustomerDbContext db) =>
{
    db.Customers.Add(customer);
    await db.SaveChangesAsync();
    return Results.Created($"/api/customers/{customer.CustomerId}", customer);
});

// Map Aspire health check endpoints
app.MapDefaultEndpoints();

app.Run();
