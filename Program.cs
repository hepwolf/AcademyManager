using AcademyManager.Application.Services;
using AcademyManager.Domain.Repositories;
using AcademyManager.Domain.Repositories.CommandRepositories;
using AcademyManager.Domain.Repositories.QueryRepositories;
using AcademyManager.Infrastructure.DbContexts;
using AcademyManager.Infrastructure.Repositories.CommandRepositories;
using AcademyManager.Infrastructure.Repositories.QueryRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Paket;
using System.Configuration;
using System.Text;
 
var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddDbContext<AcademyDbContext>(options => 
    {
        options.UseSqlServer(builder.Configuration["ConnectionStrings:SqlConnection"]); 
    });
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

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
           ValidIssuer = builder.Configuration["Issuer"],
           ValidAudience = builder.Configuration["Audience"],
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
       };
   });

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

}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}