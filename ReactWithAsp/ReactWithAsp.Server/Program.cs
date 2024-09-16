using Microsoft.EntityFrameworkCore;
using ReactWithAsp.Server.Data;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;
var mysqlDb = config["MySQL:Db"];
var mysqlUser = config["MySQL:User"];
var mysqlPassword = config["MySQL:Password"];
var mysqlConn = $"server=localhost;port=3306;user={mysqlUser};password={mysqlPassword};database={mysqlDb};CharSet=utf8;TreatTinyAsBoolean = false";
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(mysqlConn, ServerVersion.AutoDetect(mysqlConn)
    ));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
