using Microsoft.EntityFrameworkCore;
using ProjetoBase.Infrastructure.Context;
using ProjetoBase.Application.Interfaces;
using ProjetoBase.Application.Services;
using ProjetoBase.Domain.Interfaces;
using ProjetoBase.Infrastructure.Repositories;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Configurações de Serviços (Injeção de Dependência)

// Controllers
builder.Services.AddControllers();

// Swagger (documentação da API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MySQL com Pomelo
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

// Injeção de dependência - Services e Repositories
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// CORS (liberar requisições de qualquer origem por enquanto)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Autenticação e autorização (deixa preparado para futuro)
builder.Services.AddAuthentication(); // Aqui entra JWT depois
builder.Services.AddAuthorization();

var app = builder.Build();

// 🔧 Pipeline de Middlewares

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();




