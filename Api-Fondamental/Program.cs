
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Api_Fondamental.Hubs;
using Api_Fondamental.Infrastructure;
using Asp.Versioning;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ToolBox;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddTransient<IConnection, Connection>(sp => new Connection(builder.Configuration.GetConnectionString("Fondamental")));
        builder.Services.AddTransient<IDbConnection, SqlConnection>(sp => new SqlConnection(builder.Configuration.GetConnectionString("Fondamental")));
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<Iservice<StudentModel>, StudentService>();
        builder.Services.AddScoped<Iservice<RoleModel>, RoleService>();
        builder.Services.AddScoped<Iservice<PdfCourseModel>, PdfCourseService>();
        builder.Services.AddScoped<Iservice<MessageHubModel>, MessageHubService>();
        builder.Services.AddScoped<Iservice<FormationModel>, FormationService>();
        builder.Services.AddScoped<Iservice<ExplicationModel>, ExplicationService>();
        builder.Services.AddScoped<Iservice<CourseModel>, CourseService>();

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IRepository<StudentEntity>, StudentRepository>();
        builder.Services.AddScoped<IRepository<RoleEntity>, RoleRepository>();
        builder.Services.AddScoped<IRepository<PdfCourseEntity>, PdfCourseRepository>();
        builder.Services.AddScoped<IRepository<MessageHubEntity>, MessageHubRepository>();
        builder.Services.AddScoped<IRepository<FormationEntity>, FormationRepository>();
        builder.Services.AddScoped<IRepository<ExplicationEntity>, ExplicationRepository>();
        builder.Services.AddScoped<IRepository<CourseEntity>, CourseRepository>();

        builder.Services.AddScoped<TokenGenerator>();
        builder.Services.AddAuthorization(o =>
        {
            o.AddPolicy("AdminPolicy", option => option.RequireRole("Admin"));
            o.AddPolicy("ModoPolicy", option => option.RequireRole("Admin", "Modo"));
            o.AddPolicy("UserPolicy", option => option.RequireAuthenticatedUser());
        });
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(option =>
        {
            option.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenGenerator.secretKey)),
                ValidateLifetime = true,
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

        //Gestion du versionning
        //builder.Services.AddApiVersioning(opt =>
        //{
        //    opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
        //    opt.AssumeDefaultVersionWhenUnspecified = true;
        //    opt.ReportApiVersions = true;
        //    opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(), new
        //       HeaderApiVersionReader("x-api-version"), new
        //    MediaTypeApiVersionReader("x-api-version"));
        //});
        //builder.Services.AddVersionedApiExplorer(setup =>
        //{
        //    setup.GroupNameFormat = "'v'VVV";
        //    setup.SubstituteApiVersionInUrl = true;
        //});
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v2.0",
                Title = "Fondamental",
                Description = "Api de projet de fin de formation",
                Contact = new OpenApiContact
                {
                    Name = "Fondamental 2.0",
                    Url = new Uri("https://www.cognitic.be")
                }
            });
            options.SwaggerDoc("v2", new OpenApiInfo
            {
                Version = "v2",
                Title = "Fondamental 2.0",
                Description = "Api de renvoi de donnees ",
                Contact = new OpenApiContact
                {
                    Name = "Fondamental 2.0",
                    Url = new Uri("https://www.cognitic.be")
                }
            });
        });

        builder.Services.AddCors(o => o.AddPolicy("myPolicy", options =>
        options.WithOrigins("http://localhost:4200", "https://localhost:7107")
            .AllowCredentials()));

        builder.Services.AddSignalR();

        builder.Services.AddSingleton<ChatHub>();



        var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger(options => options.RouteTemplate = "swagger/{documentName}/swagger.Json");
                app.UseSwaggerUI(options =>
                {
                    options.DocumentTitle = "Fondamental";
                    options.SwaggerEndpoint($"/swagger/v1/swagger.Json", $"Fondamental v1");
                    options.SwaggerEndpoint($"/swagger/v2/swagger.Json", $"v2 en construction");
                    
                });
            }
        
        app.UseCors(o => o.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
        app.UseHttpsRedirection();

        app.UseAuthentication();            
        app.UseAuthorization();

        app.MapControllers();

        app.MapHub<ChatHub>("chat");

        app.Run();
    }
}

