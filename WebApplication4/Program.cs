using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Repository.CityRepository;
using WebApplication4.Repository.CountryRepository;
using WebApplication4.Repository.ProfileRepository;
using WebApplication4.Repository.StateRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IStateRepository, StateRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();



var connectionstring = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<DataContext>(options =>options.UseNpgsql(connectionstring));
var app = builder.Build();



app.UseSwagger();

app.UseSwaggerUI();
app.MapControllers();

app.UseHttpsRedirection();

app.Run();

