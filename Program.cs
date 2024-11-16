using AcademyManager.Application.Services;
using AcademyManager.Application.Services.Service;
using AcademyManager.Application.Validators;
using AcademyManager.Domain.Repositories;
using AcademyManager.Domain.Repositories.CommandRepositories;
using AcademyManager.Domain.Repositories.QueryRepositories;
using AcademyManager.Infrastructure.DbContexts;
using AcademyManager.Infrastructure.Repositories.CommandRepositories;
using AcademyManager.Infrastructure.Repositories.QueryRepositories;
using AcademyManager.Middelware;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Paket;
using System.Configuration;
using System.Reflection;
using System.Text;
using ReferenceType = Microsoft.OpenApi.Models.ReferenceType;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddDbContext<AcademyDbContext>(options => 
    {
        options.UseSqlServer(builder.Configuration["ConnectionStrings:SqlConnection"]); 
    });
    builder.Services.AddControllers();

    builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

    //builder.Services.AddFluentValidation(config =>
    //{
    //    config.RegisterValidatorsFromAssemblyContaining<LoginValidator>();
    //    config.RegisterValidatorsFromAssemblyContaining<RegisterValidator>();
    //    config.DisableDataAnnotationsValidation = true;
    //});


    builder.Services.AddEndpointsApiExplorer();
    

    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

       
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Please enter token in the following format: Bearer {your token}"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
    });


    builder.Services.AddAuthentication(options =>

   {
       options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
       options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
   })
   .AddJwtBearer(options =>
   {
       options.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuer = true,
           ValidateAudience = true,
           ValidateLifetime = true,
           ValidateIssuerSigningKey = true,
           ValidIssuer = builder.Configuration["Jwt:Issuer"],
           ValidAudience = builder.Configuration["Jwt:Audience"],
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
       };
   });

       builder.Services.AddScoped<RoleClaimsMiddleware>();
      builder.Services.AddScoped<GlobalExceptionMiddelware>();
    builder.Services.AddAuthorization();

    
    builder.Services.AddScoped<IAcademyQueryRepository,AcademyQueryRepository>();
        builder.Services.AddScoped<IAcademyCommandRepository,AcademyCommandRepository>();
          builder.Services.AddScoped<ICourseQueryRepository, CourseQueryRipository>();
           builder.Services.AddScoped<ICourseCommandRepository, CourseComandRepository>();
             builder.Services.AddScoped<IStudentCommandRepository,StudentCommandRepository>();
              builder.Services.AddScoped<IStudentQueryRepository,StudentQueryRepository>(); 
              builder.Services.AddScoped<IUserCommandRepository,UserCommandRepository>();
            builder.Services.AddScoped<IUserQueryRepository,UserQueryRepository>(); 
         builder.Services.AddScoped<IStudentServices, StudentServices>();
        builder.Services.AddScoped<ICourseServices, CourseServices>();
       builder.Services.AddScoped<IAcademyServices, AcademyServices>();  
       builder.Services.AddScoped<IUserServices, UserServices>();
     builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
    builder.Services.AddScoped<IRoleCommandRepository, RoleCommandRepository>();
    builder.Services.AddScoped<IRoleQueryRepositry,RoleQueryRepository>();
                 builder.Services.AddScoped<IRoleServices, RoleServices>();
                    builder.Services.AddScoped<IUserRoleQueryRepository,UserRoleQuryRepository>();
                  builder.Services.AddScoped<IUserRoleCommandRepository,UserRoleCommandRepository>(); 
    builder.Services.AddScoped<IUserRoleService ,UserRoleService>();
   
}

var app = builder.Build();
{

    // Configure the HTTP request pipeline.
    
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
        });
    }
    
    app.UseHttpsRedirection();
    app.UseMiddleware<GlobalExceptionMiddelware>();
    app.UseAuthentication();
    app.UseMiddleware<RoleClaimsMiddleware>();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}