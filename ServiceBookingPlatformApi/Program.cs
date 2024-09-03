using Data;
using Core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ������ ������ �� ����������
builder.Services.AddControllers();

// ������������ Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ������ Entity Framework � �������� ���� �����
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ������ AutoMapper
builder.Services.AddMapping();

// ������ ������� ������
builder.Services.AddCoreServices();

// ������ ������ ����������
builder.Services.AddRepositories();

var app = builder.Build();

// ������������ ������� HTTP ������
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();