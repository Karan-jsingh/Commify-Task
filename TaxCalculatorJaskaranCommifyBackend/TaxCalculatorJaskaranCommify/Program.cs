using Microsoft.EntityFrameworkCore;
using TaxCalculator.Infrastructure.Data;
using TaxCalculator.Infrastructure.Repositories;
using TaxCalculatorJaskaranCommify.Core.Entities;
using TaxCalculatorJaskaranCommify.Core.Interfaces;
using TaxCalculatorJaskaranCommify.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("TaxCalculatorDb"));

builder.Services.AddScoped<IIncomeTaxBandRepository, TaxBandRepository>();
builder.Services.AddScoped<ICalculateIncomeTax, CalculateIncomeTax>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200") 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();


app.UseCors("AllowAngular");

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    context.Database.EnsureCreated(); 
    if (!context.TaxBands.Any())
    {
        context.TaxBands.AddRange(
            new IncomeTaxBand { Id = 1, MinimumIncomeThreshold = 0, MaximumIncomeThreshold = 5000, TaxRate = 0 },
            new IncomeTaxBand { Id = 2, MinimumIncomeThreshold = 5000, MaximumIncomeThreshold = 20000, TaxRate = 20 },
            new IncomeTaxBand { Id = 3, MinimumIncomeThreshold = 20000, MaximumIncomeThreshold = decimal.MaxValue, TaxRate = 40 }
        );
        context.SaveChanges();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
public partial class Program { }
