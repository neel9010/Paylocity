using Paylocity.Data.Implementations;
using Paylocity.Data.Interfaces;
using Paylocity.Services.Impementations;
using Paylocity.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDeductionService, DeductionService>();
builder.Services.AddSingleton<IBenefitsService, BenefitsServices>();
builder.Services.AddSingleton<IPayrollService, PayrollService>();
builder.Services.AddSingleton<IPayCheckService, PayCheckService>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IPayCheckRepository, PayCheckRepository>();

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