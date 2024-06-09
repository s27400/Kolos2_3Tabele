using Microsoft.EntityFrameworkCore;
using WebApplication2.Entities;
using WebApplication2.Repositories;
using WebApplication2.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IHospitalRepository, HospitalRepostiory>();
builder.Services.AddScoped<IHospitalService, HospitalService>();

builder.Services.AddDbContext<HospitalDbContext>(opt =>
{
    string con = builder.Configuration.GetConnectionString("Default");
    opt.UseSqlServer(con);
});

//dotnet new tool-manifest
//dotnet tool install dotnet-ef
//dotnet ef migrations add Init
//dotnet ef database update

//Microsoft.EntityFrameworkCore
//Microsoft.EntityFrameworkCore.SqlServer
//Microsoft.EntityFrameworkCore.Design

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();


app.Run();

