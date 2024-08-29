using AutomationOfThePurchasingActOfRestaurant;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    var dir = new DirectoryInfo(AppContext.BaseDirectory);
    var doc = XDocument
    .Load($"{dir}\\AutomationOfThePurchasingActOfRestaurant.xml");
    opt.IncludeXmlComments(
        () => new System.Xml.XPath.XPathDocument(doc.CreateReader()), true);
});
builder.Services.AddDbContext<PurchasingDbContext>(
    options =>
    {
        options.UseNpgsql(configuration
            .GetConnectionString(nameof(PurchasingDbContext)));
    }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
