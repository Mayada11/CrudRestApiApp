using CrudRestApiApp.DepartmentData;
using CrudRestApiApp.EmployeeData;
using CrudRestApiApp.Models;
using CrudRestApiApp.NewFolder;
using CrudRestApiApp.ProjectData;
using CrudRestApiApp.WorksOnData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudRestApiApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddDbContext<SD_CompanyContext>(op => op.UseSqlServer(Configuration.GetConnectionString("Database"))); //Add       
            services.AddControllers();
            services.AddScoped<IDepartmentData, SqlDepartmentData>();
            services.AddScoped<IProjectData, SqlProjectData>();
            services.AddScoped<IEmployeeData, SqlEmolyeeData>();
            services.AddScoped<IWorksOnData, SqlWorksOnData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
