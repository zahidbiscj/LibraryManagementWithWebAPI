using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using LibraryWithWebApiConsole.Store;
using LibraryWithWebApiConsole.Store.IServices;
using LibraryWithWebApiConsole.Store.IRepository;
using LibraryWithWebApiConsole.Store.Services;
using LibraryWithWebApiConsole.Store.Repository;

namespace Assignment_6_LibraryWithWebApi
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
            var migrationAssemblyName = typeof(Startup).Assembly.FullName;
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services
                .AddTransient<IMembershipService, MembershipService>()
                .AddTransient<IStudentRepository, StudentRepository>();
            services
                .AddTransient<IBookService, BookService>()
                .AddTransient<IBookRepository, BookRepository>();
            services
                .AddTransient<IManageLibraryServices, ManageLibraryServices>()
                .AddTransient<IBookIssueRepository, BookIssueRepository>();
            services
                .AddTransient<IReportingService,ReportingService>()
                .AddTransient<IReturnBookRepository,ReturnBookRepository>();
            services
                .AddTransient<LibraryUnitOfWork>(x => new LibraryUnitOfWork(connectionString, migrationAssemblyName))
                .AddTransient<LibraryContext>(x => new LibraryContext(connectionString, migrationAssemblyName));

            services.AddDbContext<LibraryContext>(x => x.UseSqlServer(connectionString, m => m.MigrationsAssembly(migrationAssemblyName)));


            services.AddDbContext<LibraryContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
