using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using SchedulerApi;

var builder = WebApplication.CreateBuilder(args);

// Existing code
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Temporary test
MongoTest.TestConnection();

// Existing code
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();