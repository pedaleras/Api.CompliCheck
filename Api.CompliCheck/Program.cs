using Api.CompliCheck.Data;
using Api.CompliCheck.Repositories;
using Api.CompliCheck.Services;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = CreateBuilder(args);
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
    }

    public static WebApplicationBuilder CreateBuilder(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        #region Injeções de Dependência
        builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
        builder.Services.AddScoped<INormaRepository, NormaRepository>();
        builder.Services.AddScoped<IEmpresaService, EmpresaService>();
        builder.Services.AddScoped<INormaService, NormaService>();
        #endregion

        #region Configuração do banco de dados
        var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
        builder.Services.AddDbContext<DatabaseContext>(context =>
            context.UseOracle(connectionString).EnableSensitiveDataLogging(true));
        #endregion

        return builder;
    }
}
