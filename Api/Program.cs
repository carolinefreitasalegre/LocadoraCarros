using System.Text;
using Application.AutoMapper;
using Application.Contratos.AdminInterfaceUseCase;
using Application.Contratos.CarInterfaceUseCase;
using Application.Contratos.CreateRentalClientInterfacceUseCase;
using Application.Contratos.RentalInterfaceUseCase;
using Application.Dtos.Request.CreateCarRequest;
using Application.Dtos.Request.RequestAdmin;
using Application.Dtos.Request.RequestClient;
using Application.Dtos.Request.RequestRental;
using Application.UseCases.AdminUseCase;
using Application.UseCases.CarUseCase;
using Application.UseCases.CreateRentalClientUseCase;
using Application.UseCases.RentalUseCase;
using Application.Validations;
using Domain.Contratos.AdminInterface;
using Domain.Contratos.CarInterface;
using Domain.Contratos.RentalClientInterfaceRepository;
using Domain.Contratos.RentalInterfaceRepository;
using FluentValidation;
using Infrastructure.DataAccess;
using Infrastructure.Repositories.AdminRepositories;
using Infrastructure.Repositories.CarRepositories;
using Infrastructure.Repositories.RentalClienRepository;
using Infrastructure.Repositories.RentalRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var TokenSecreto = "a086c60e-bfc2-43b6-8b9c-29cf85042522";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Locadora de Carros - API", Version = "v1" });

    var securitySchema = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Entre com o Token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme,
        }


    };
    c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securitySchema);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securitySchema, new string[] {} }
    });

});




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


builder.Services.AddScoped<ICreateRentalRepository, CreateRentalRepository>();
builder.Services.AddScoped<ICreateRentalUseCase, CreateRentalUseCase>();


builder.Services.AddTransient<IValidator<CreateAdminRequest>, CreateAdminValidator>();
builder.Services.AddTransient<IValidator<CreateCarRequest>, CreateCarValidator>();
builder.Services.AddTransient<IValidator<CreateRentalClientRequest>, CreateRentalClientValidator>();
builder.Services.AddTransient<IValidator<RentalRequest>, CreateRentalValidator>();

builder.Services.AddAutoMapper(typeof(MappingProfile));




builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "api_locadora",
        ValidAudience = "api",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenSecreto))

    };

});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
