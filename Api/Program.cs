using Application.AutoMapper;
using Application.Contratos.AdminInterfaceUseCase;
using Application.Contratos.CarInterfaceUseCase;
using Application.Contratos.CreateRentalClientInterfacceUseCase;
using Application.Dtos.Request.CreateCarRequest;
using Application.Dtos.Request.RequestAdmin;
using Application.Dtos.Request.RequestClient;
using Application.UseCases.AdminUseCase;
using Application.UseCases.CarUseCase;
using Application.UseCases.CreateRentalClientUseCase;
using Application.Validations;
using Domain.Contratos.AdminInterface;
using Domain.Contratos.CarInterface;
using Domain.Contratos.RentalClientInterfaceRepository;
using FluentValidation;
using Infrastructure.DataAccess;
using Infrastructure.Repositories.AdminRepositories;
using Infrastructure.Repositories.CarRepositories;
using Infrastructure.Repositories.RentalClienRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});

builder.Services.AddScoped<ICreateAdminUseCase, CreateAdminUseCase>();
builder.Services.AddScoped<ICreateAdminRepository, CreateAdminRepository>();


builder.Services.AddScoped<ICreateCarRepository, CreateCarRepository>();
builder.Services.AddScoped<ICreateCarUseCase, CreateCarUSeCase>();


builder.Services.AddScoped<ICreateRentalClientRepository, CreateRentalClientRepository>();
builder.Services.AddScoped<ICreateRentalClientUseCase, CreateRentalClientUseCase>();


builder.Services.AddTransient<IValidator<CreateAdminRequest>, CreateAdminValidator>();
builder.Services.AddTransient<IValidator<CreateCarRequest>, CreateCarValidator>();
builder.Services.AddTransient<IValidator<CreateRentalClientRequest>, CreateRentalClientValidator>();

builder.Services.AddAutoMapper(typeof(MappingProfile));


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
