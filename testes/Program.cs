using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using testes.Repositories;
using testes.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicionando servi�os ao cont�iner
builder.Services.AddControllers();

// Adicionando o Swagger
builder.Services.AddEndpointsApiExplorer(); // Adiciona suporte para API explorer
builder.Services.AddSwaggerGen(); // Adiciona o Swagger Generator

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();

var app = builder.Build();

// Configurando o pipeline de requisi��o
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Habilitando o middleware do Swagger
app.UseSwagger(); // Habilita o middleware do Swagger
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    c.RoutePrefix = "swagger";
});

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
