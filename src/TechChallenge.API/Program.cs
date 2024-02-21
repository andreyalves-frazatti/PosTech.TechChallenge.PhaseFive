using TechChallenge.Application.Settings;
using TechChallenge.Infrastructure.MongoDB.Settings;
using TechChallenge.Infrastructure.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMongoRepositories(builder.Configuration);
builder.Services.AddGateways();
builder.Services.AddCommands();

builder.Services.AddControllers();
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