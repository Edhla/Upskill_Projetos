using LibGerenciadorOficina.DTOs;
using LibGerenciadorOficina.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebAppiGnOfficina.Services;

namespace WebAppiGnOfficina
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Builders
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("cors",
                    policy =>
                    {
                        policy
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            var secret_key = builder.Configuration["App:JWT:SECRET_KEY"];
            var key = Encoding.UTF8.GetBytes(secret_key);
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = "gerenciadoroficina",
                    ValidAudience = "gerenciadoroficina",

                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(type => type.FullName.Replace("+", "."));

                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Enter 'Bearer {token}'"
                });

                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
        {
            {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
            });

            builder.Services.AddScoped<IMarcaRepository, MarcaRepository>();
            builder.Services.AddScoped<IMarcaService, MarcaService>();
            builder.Services.AddScoped<IModeloRepository, ModeloRepository>();
            builder.Services.AddScoped<IModeloService, ModeloService>();
            builder.Services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            builder.Services.AddScoped<IVeiculoService, VeiculoService>();

            builder.Services.AddAuthorization();

            var app = builder.Build();
            #endregion

            app.UseCors("cors");

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseAuthentication();
            app.UseAuthorization();

            #region Endpoints
            app.MapGet("/", () => "WebApi - Gerenciador de oficina");

            // Endpoints de Marcas
            // Get ALL
            app.MapGet("/marcas", (IMarcaService service) =>
            {

                return service.GetAll();
            });

            // Get by ID
            app.MapGet("/marcas/{id}", (int id, IMarcaService service) =>
            {
                var m = service.GetById(id);

                return m == null ? Results.NotFound() : Results.Ok(m);
            });

            // Insert

            app.MapPost("/marcas", (MarcaDTO marca, IMarcaService service) =>
            {
                int id = service.Insert(marca);

                return Results.Created($"/marcas/{id}", new { id });
            });

            // Update

            app.MapPut("/marcas", (MarcaDTO dto, IMarcaService service) =>
            {
                service.Update(dto);

                return Results.Ok();
            });

            // Delete

            app.MapDelete("/marcas/{id}", (int id, IMarcaService service) =>
            {
                service.Delete(id);

                return Results.Ok();
            });

            // Endpoints de Modelos
            // Get ALL
            app.MapGet("/modelos", (IModeloService service) =>
            {

                return service.GetAll();
            });

            // Get by ID
            app.MapGet("/modelos/{id}", (int id, IModeloService service) =>
            {
                var m = service.GetById(id);

                return m == null ? Results.NotFound() : Results.Ok(m);
            });

            // Insert

            app.MapPost("/modelos", (ModeloDTO dto, IModeloService service) =>
            {
                int id = service.Insert(dto);

                return Results.Created($"/marcas/{id}", new { id });
            });

            // Update

            app.MapPut("/modelos", (ModeloDTO dto, IModeloService service) =>
            {
                service.Update(dto);

                return Results.Ok();
            });

            // Delete

            app.MapDelete("/modelos/{id}", (int id, IModeloService service) =>
            {
                service.Delete(id);

                return Results.Ok();
            });

            // Endpoints de Veiculos
            // Get ALL
            app.MapGet("/veiculos", (IVeiculoService service) =>
            {

                return service.GetAll();
            });

            // Get by ID
            app.MapGet("/veiculos/{id}", (int id, IVeiculoService service) =>
            {
                var v = service.GetById(id);

                return v == null ? Results.NotFound() : Results.Ok(v);
            });

            // Insert

            app.MapPost("/veiculos", (VeiculoDTO dto, IVeiculoService service) =>
            {
                int id = service.Insert(dto);

                return Results.Created($"/veiculos/{id}", new { id });
            });

            // Update

            app.MapPut("/veiculos", (VeiculoDTO dto, IVeiculoService service) =>
            {
                service.Update(dto);

                return Results.Ok();
            });

            // Delete

            app.MapDelete("/veiculos/{id}", (int id, IVeiculoService service) =>
            {
                service.Delete(id);

                return Results.Ok();
            });

            #endregion

            app.Run();
        }
    }
}
