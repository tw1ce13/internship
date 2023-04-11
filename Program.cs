using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using ProjectJunior.Models;
using ProjectJunior.Data;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Data.Repositories;
using ProjectJunior.Services.Interfaces;
using ProjectJunior.Services.Implementations;
using ProjectJunior.Data.Implementations;

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


builder.Services.AddScoped<IGeneralRepository<Availability>, AvailabilityRepository>();
builder.Services.AddScoped<IGeneralRepository<Discount>, DiscountRepository>();
builder.Services.AddScoped<IGeneralRepository<Class>, ClassRepository>();
builder.Services.AddScoped<IGeneralRepository<Delivery>, DeliveryRepository>();
builder.Services.AddScoped<IGeneralRepository<Drug>, DrugRepository>();
builder.Services.AddScoped<IGeneralRepository<Employee>, EmployeeRepository>();
builder.Services.AddScoped<IGeneralRepository<OrdDrug>, OrdDrugRepository>();
builder.Services.AddScoped<IGeneralRepository<Ord>, OrdRepository>();
builder.Services.AddScoped<IGeneralRepository<Patient>, PatientRepository>();
builder.Services.AddScoped<IGeneralRepository<Pharmacy>, PharmacyRepository>();
builder.Services.AddScoped<IGeneralRepository<RecipeDrug>, RecipeDrugRepository>();
builder.Services.AddScoped<IGeneralRepository<Recipe>, RecipeRepository>();
builder.Services.AddScoped<IGeneralRepository<Web>, WebRepository>();


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

