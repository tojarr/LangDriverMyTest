using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace LangDriverApi.Extensions
{
    public static class SwaggerServicesExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Lang Driver API",
                    Description = "Lang Driver ASP.NET Core Web API",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Gummi", Email = "akovanev@gmail.com", Url = "http://localhost" }
                });
                c.IncludeXmlComments(System.IO.Path.Combine(AppContext.BaseDirectory, "LangDriverApi.xml"));
            });
        }

        public static void UseSwaggerWithUI(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lang Driver API V1");
                c.InjectStylesheet("/swagger-ui/material.css");
            });
        }
    }
}
