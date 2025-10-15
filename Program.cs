// Program.cs teste
using LojaApi.Repositories;
using LojaApi.Repositories.Interfaces;
using LojaApi.Services;
using LojaApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços ao contêiner de injeção de dependência.
builder.Services.AddControllers();

// >>>>> CONFIGURAÇÃO DA INJEÇÃO DE DEPENDÊNCIA (DI) <<<<<

// >>>>> CONFIGURAÇÃO DO ENTITY FRAMEWORK CORE E DI <<<<<
// 1. Configuração do DbContext com PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LojaApi.Data.LojaContext>(options =>
    options.UseNpgsql(connectionString));

// 1. Registro do Serviço
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

// 2. Registro do Repositório
//    Sempre que alguém (como o ClienteService) pedir a Interface IClienteRepository,
//    entregue a implementação (mockada) ClienteRepository.
builder.Services.AddScoped<IClienteRepository, ClienteDbRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoDbRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaDbRepository>();

// Configuração do Swagger teste
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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