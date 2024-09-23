using Data;
using Core;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using FluentValidation;
using ServiceBookingPlatformApi.Middlewares;
using Data.DataInitializer;
using Core.Models;
using ServiceBookingPlatformApi.ServiceExtensions;
using ServiceBookingPlatformApi;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// ������ ������ �� ����������
builder.Services.AddControllers();

// ����������� JwtOptions ����� ������� �����
builder.Services.AddJwtOptions(builder.Configuration);

// �������� ������������ JWT
var jwtOpts = builder.Configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>()!;

// ��������� ���������� ��� JWT
builder.Services.AddJwtAuthentication(jwtOpts);

// ��������� ����� ��� �������������� ������
builder.Services.AddAuthorizationPolicies();

// ������������ Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerJWT();

builder.Services.AddHangfire(connectionString!);

// ������������ Identity � ������������� �����
builder.Services.AddIdentityWithRoles();

// ������ Entity Framework � �������� ���� �����
builder.Services.AddAppDbContext(connectionString!);

// ������ AutoMapper
builder.Services.AddMapping();

// ������ ������ ������
builder.Services.AddCoreServices();

// ������ ������ ����������
builder.Services.AddRepositories();

// fluent validators
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.SeedRoles().Wait();
    scope.ServiceProvider.SeedAdmin().Wait();

}
// ������������ ������� HTTP ������
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CustomMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseHangfireDashboard("/dash");
JobConfigurator.AddJobs(); 
app.MapControllers();
app.Run();
