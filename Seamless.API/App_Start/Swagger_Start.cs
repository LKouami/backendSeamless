using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Seamless.API.App_Start
{
    public static class Swagger_Start
    {
        public static void UseSwaggerAndUI(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Seamless Api",
                    Description = "Seamless Api",
                    Contact = new OpenApiContact
                    {
                        Name = "Klein Houzin",
                        Email = "klein.houzin@gmail.com",
                    }
                });

                c.DescribeAllParametersInCamelCase();

                // Set the comments path for the Swagger JSON and UI.
                
            });

        }

        public static void UseSwaggerAndUI(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Seamless API V1"); });
        }
    }
}
