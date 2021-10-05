using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace Expense_Calculator_Business
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion
            (CompatibilityVersion.Version_2_2);
           
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Expense Calculator API",
                        Description = "Expense Calculator Business API",
                        TermsOfService = new Uri("https://pragimtech.com"),
                        Contact = new OpenApiContact
                        {
                            Name = "Prakhar Gupta",
                            Email = "prakhar140597@gmail.com",
                            
                        },
                        License = new OpenApiLicense
                        {
                            Name = "______ Open License",
                            
                        }
                    });
                });
            
        }
        public void Configure(IApplicationBuilder app,
       IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}