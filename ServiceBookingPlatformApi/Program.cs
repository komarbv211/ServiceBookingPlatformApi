using Data;
using Core;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using FluentValidation;
using ServiceBookingPlatformApi.Middlewares;
using Microsoft.AspNetCore.Identity;
using Data.Entities;
using Data.DataInitializer;

var builder = WebApplication.CreateBuilder(args);

// Додаємо сервіси до контейнера
builder.Services.AddControllers();

// Налаштування Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Налаштування Identity з використанням ролей
builder.Services.AddIdentity<UserEntity, IdentityRole>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<AppDbContext>();
// Додаємо авторизацію
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("ServiceProviderOnly", policy => policy.RequireRole("ServiceProvider"));
    options.AddPolicy("ClientOnly", policy => policy.RequireRole("Client"));
});

// Додаємо Entity Framework і контекст бази даних
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Додаємо AutoMapper
builder.Services.AddMapping();

// Додаємо основні сервіси
builder.Services.AddCoreServices();

// Додаємо сервіси репозиторіїв
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
// Налаштування конвеєра HTTP запитів
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CustomMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
