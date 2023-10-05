using Microsoft.OpenApi.Models;
using System.Net;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Design;
using Npgsql.EntityFrameworkCore.PostgreSQL.Design;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Npgsql.EntityFrameworkCore.PostgreSQL.Design.Internal;
using Microsoft.Extensions.DependencyInjection ;
using AgendaMvcProject.Data.IoC;
using AgendaMvcProject.Data.Repositories;
using AgendaMvcProject.Application.Interfaces;
using AgendaMvcProject.Application.Services;
using AgendaMvcProject.Domain.Interfaces;
using AgendaMvcProject.Application.Mappings;
using Microsoft.AspNetCore.Authentication.Cookies;
using AgendaMvcProject.Data.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var AllowOrigin = "AllowOrigin";


var builder = WebApplication.CreateBuilder(args);


        // builder.Services.AddScoped<IContactRepository, ContactRepository>();

        // builder.Services.AddScoped<IContactService, ContactService>();



        // builder.Services.AddAutoMapper(typeof(ModelToDTOMapping));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowOrigin,
                      policy =>
                      {
                          policy.AllowAnyMethod()
                          .AllowAnyHeader()
                          .WithOrigins("http://localhost:3000")
                        //   .AllowAnyOrigin()
                          .AllowCredentials();
                      });
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);
// builder.Services.AddInfrastructureSwagger();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IDesignTimeServices>(new NpgsqlDesignTimeServices());


// builder.Services.AddDbContext<ApplicationContext>(options =>
//          options.UseNpgsql(configuration.GetConnectionString("Server=localhost:5432;Database=postgres;User Id=postgres;Password=changeme;TrustServerCertificate=True"
//         ), b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
        options => builder.Configuration.Bind("CookieSettings", options));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors(AllowOrigin);
// builder.Services.AddAuthentication(options =>
//             {
//                 options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//             });


// builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//     .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
//         options => builder.Configuration.Bind("CookieSettings", options));
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
