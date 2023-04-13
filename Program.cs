using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using ProjectJunior.Models;
using ProjectJunior.Data;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Data.Repositories;
using ProjectJunior.Services.Interfaces;
using ProjectJunior.Services.Implementations;
using ProjectJunior.Data.Implementations;
using ProjectJunior.Data.IRepositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<ProjectContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<IAvailabilityService, AvailabilityService>();
builder.Services.AddTransient<IClassService, ClassService>();
builder.Services.AddTransient<IDeliveryService, DeliveryService>();
builder.Services.AddTransient<IDiscountService, DiscountService>();
builder.Services.AddTransient<IDrugService, DrugService>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IOrdDrugService, OrdDrugService>();
builder.Services.AddTransient<IOrdService, OrdService>();
builder.Services.AddTransient<IPatientService, PatientService>();
builder.Services.AddTransient<IPharmacyService, PharmacyService>();
builder.Services.AddTransient<IRecipeDrugService, RecipeDrugService>();
builder.Services.AddTransient<IRecipeService, RecipeService>();
builder.Services.AddTransient<IWebService, WebService>();


builder.Services.AddScoped<IAvailabilityRepository, AvailabilityRepository>();
builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddScoped<IDeliveryRepository, DeliveryRepository>();
builder.Services.AddScoped<IDrugRepository, DrugRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IOrdDrugRepository, OrdDrugRepository>();
builder.Services.AddScoped<IOrdRepository, OrdRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPharmacyRepository, PharmacyRepository>();
builder.Services.AddScoped<IRecipeDrugRepository, RecipeDrugRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IWebRepository, WebRepository>();


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

