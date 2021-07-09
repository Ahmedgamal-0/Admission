using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdmissionSystem.Entities;
using AdmissionSystem.Models;
using AdmissionSystem.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebApplication1
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddScoped<IAdmissionRepo, AdmissionRepo>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<AdmissionSystemDbContext>(o => o.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database = AdmissionDB; Trusted_Connection = True;"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory LoggerFactory)

        {
            LoggerFactory.AddConsole();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
                    }
                        );

                });
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCookiePolicy();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AdmissionSystem.Models.ApplicantForCreation, AdmissionSystem.Entities.Applicant>();

                cfg.CreateMap<ParentInfoForCreation, ParentInfo>();
                cfg.CreateMap<EmergencyContactForCreation, EmergencyContact>();

                cfg.CreateMap<SiblingForCreation, Sibling>();
                cfg.CreateMap<MedicalHistoryForCreation, MedicalHistory>();


                cfg.CreateMap<Sibling, SiblingDto>();
                cfg.CreateMap<MedicalHistory, MedicalHistoryDto>();

                cfg.CreateMap<Sibling, SiblingForUpdate>();
                cfg.CreateMap<SiblingForUpdate, Sibling>();
                cfg.CreateMap<MedicalHistory, MedicalHistoryForUpdate>();
                cfg.CreateMap<MedicalHistoryForUpdate, MedicalHistory>();

            });

            app.UseMvc();

        }
    }
}
