
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Api_Fondamental.Infrastructure;
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
        var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
        app.UseCors(o => o.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
        app.UseHttpsRedirection();

        app.UseAuthentication();            
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}


//    services.AddSignalR();
//    services.AddSingleton<TokenManager>();

//    services.AddSwaggerGen(c =>
//    {
//        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Fondamental_Api", Version = "v1" });
//        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//        {
//            Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n" +
//            "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n" +
//            "Example: 'Bearer 12345abcdef'",
//            Name = "Authorization",
//            In = ParameterLocation.Header,
//            Type = SecuritySchemeType.ApiKey,
//            Scheme = "Bearer"

//        });

//        OpenApiSecurityScheme openApiSecurityScheme = new OpenApiSecurityScheme
//        {
//            Reference = new OpenApiReference
//            {
//                Type = ReferenceType.SecurityScheme,
//                Id = "Bearer"
//            },
//            Scheme = "oauth2",
//            Name = "Bearer",
//            In = ParameterLocation.Header
//        };

//        c.AddSecurityRequirement(new OpenApiSecurityRequirement()
//        {
//            //Défini une paire de clé valeur au niveau du dictionnaire
//            [openApiSecurityScheme] = new List<string>()
//        });

//    });

//    services.AddAuthorization(options =>
//    {
//        options.AddPolicy("IsConnected", policy => policy.RequireAuthenticatedUser());
//    });

//    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters()
//        {
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenManager.secret)),
//            ValidateIssuer = true,
//            ValidIssuer = TokenManager.myIssuer,
//            ValidateAudience = true,
//            ValidAudience = TokenManager.myAudience,
//        };
//    });

//    // Singletons
//    services.AddSingleton(sp => new Connection(Configuration.GetConnectionString("Fondamental")));

//    // Repositories
//    services.AddScoped<IUserRepository, UserRepository>();

//    // Services
//    services.AddScoped<IUserService, UserService>();
//}

//// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//{
//    // ajout cors permettant n'importe quel site d'accéder à l'API
//    app.UseCors("MyPolicy");

//    /*
//    // ajout d'une origine en indiquant son nom de domaine
//    app.UseCors(options =>
//    {
//        options.WithOrigins("http://http://localhost:4200").AllowAnyMethod();
//        // options.WithOrigins("mon autre site...").AllowAnyMethod();
//    });
//    */