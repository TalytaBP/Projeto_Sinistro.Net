using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProjetoSinistroAPI.Context;
using ProjetoSinistroAPI.Repositories.Interface;
using ProjetoSinistroAPI.Repositories.Repository;

public partial class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.


        builder.Services.AddDbContext<AppContextDb>(options => options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));
        builder.Services.AddTransient<IPacienteRepository, PacienteRepository>();

        builder.Services.AddHttpClient<ProjetoSinistroAPI.Services.IExternalAuthService, ProjetoSinistroAPI.Services.ExternalAuthService>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(

            c =>
            {
                c.SwaggerDoc(
                    "v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "ODONTOPREV - PACIENTES",
                        Description = "Gerenciar Pacientes",
                        Version = "v1",
                        Contact = new OpenApiContact
                        {
                            Name = "ODONTOPREV",
                            Url = new System.Uri("https://www.odontoprev.com.br/"),
                            Email = "canaisdigitais@odontoprev.com.br. "
                        }
                    }
                    );

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization Header"
                });
            }
            );

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
}
