using Microsoft.EntityFrameworkCore;
using PickupPointAPI.Data;
using PickupPointAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add Entity Framework
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!dbContext.PickupPoints.Any())
    {
        dbContext.PickupPoints.AddRange(
            new PickupPoint { Name = "Punkt 1", Address = "Yellowstreet 1, London", OpeningHours = "8:00 - 16:00", ContactNumber = "123 123 123" },
            new PickupPoint { Name = "Punkt 2", Address = "Victoriastreet 2, London", OpeningHours = "8:00 - 16:00", ContactNumber = "333 666 123" }
        );
        dbContext.SaveChanges();
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowReactApp");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
