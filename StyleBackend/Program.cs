using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StyleBackend.Controllers;
using StyleBackend.Resources.ConectionSQL;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ConexionSQLServer>(opciones =>opciones.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));

// Politicas de Cors

builder.Services.AddCors(options =>
{
    options.AddPolicy("PoliticaPermisos", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    } );
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

app.UseHttpsRedirection();

app.UseCors("PoliticaPermisos");
app.UseAuthorization();

app.MapControllers();

app.Run();