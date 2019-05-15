using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AttendanceApi.Data;
using AttendanceApi.Models;
using AttendanceApi.Repositories;
using AttendanceApi.Services;
using Attendance = AttendanceApi.Repositories.Attendance;
using Candidate = AttendanceApi.Repositories.Candidate;
using CandidatePhoto = AttendanceApi.Repositories.CandidatePhoto;
using Organisation = AttendanceApi.Repositories.Organisation;
using OrganisationGroup = AttendanceApi.Repositories.OrganisationGroup;
using OrganisationUser = AttendanceApi.Repositories.OrganisationUser;

namespace AttendanceApi
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(o =>
                {
                    o.Password.RequireDigit = false;
                    o.Password.RequireLowercase = false;
                    o.Password.RequireUppercase = false;
                    o.Password.RequireNonAlphanumeric = false;
                    o.Password.RequiredLength = 6;
                    o.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>( )
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc().AddJsonOptions(options =>
            {
                // options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            }); ;

            services.AddScoped<IOrganisation, Organisation>();
            services.AddScoped<IOrganisationGroup, OrganisationGroup>();
            services.AddScoped<IOrganisationUser, OrganisationUser>();
            services.AddScoped<ICandidate, Candidate>();
            services.AddScoped<ICandidatePhoto, CandidatePhoto>();
            services.AddScoped<IAttendance, Attendance>();





        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
