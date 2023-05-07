using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace CadmusGraphStudioApi;

public sealed class Program
{
    private static void DumpEnvironmentVars()
    {
        Console.WriteLine("ENVIRONMENT VARIABLES:");
        IDictionary dct = Environment.GetEnvironmentVariables();
        List<string> keys = new();
        var enumerator = dct.GetEnumerator();
        while (enumerator.MoveNext())
        {
            keys.Add(((DictionaryEntry)enumerator.Current).Key.ToString()!);
        }

        foreach (string key in keys.OrderBy(s => s))
            Console.WriteLine($"{key} = {dct[key]}");
    }

    private static void ConfigureCorsServices(IServiceCollection services,
        IConfiguration configuration)
    {
        string[] origins = new[] { "http://localhost:4200" };

        IConfigurationSection section = configuration.GetSection("AllowedOrigins");
        if (section.Exists())
        {
            origins = section.AsEnumerable()
                .Where(p => !string.IsNullOrEmpty(p.Value))
                .Select(p => p.Value!).ToArray();
        }

        services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
        {
            builder.AllowAnyMethod()
                .AllowAnyHeader()
                // https://github.com/aspnet/SignalR/issues/2110 for AllowCredentials
                .AllowCredentials()
                .WithOrigins(origins);
        }));
    }

    public static int Main(string[] args)
    {
        try
        {
            Console.WriteLine("Starting Cadmus Graph Studio API host");
            DumpEnvironmentVars();

            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // CORS
            ConfigureCorsServices(builder.Services, builder.Configuration);

            // add services to the container
            builder.Services.AddControllers();

            // Swagger/OpenAPI: https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("CorsPolicy");
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Cadmus Graph Studio API host terminated unexpectedly");
            Debug.WriteLine(ex.ToString());
            Console.WriteLine(ex.ToString());
            return 1;
        }
    }
}