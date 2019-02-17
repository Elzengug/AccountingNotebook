using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingNotebook.BLL.Providers.Contracts;
using AccountingNotebook.BLL.Providers.Implementations;
using AccountingNotebook.DAL.Data.Contracts;
using AccountingNotebook.DAL.Data.Implementations;
using AccountingNotebook.DAL.Data.Repositories.Contracts;
using AccountingNotebook.DAL.Data.Repositories.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AccountingNotebook
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
            services.AddRouting();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });
            services.AddDbContextPool<AccountNotebookDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvcCore()
                .AddApiExplorer()
                .AddJsonFormatters();
            services.AddTransient<IDbContext, AccountNotebookDbContext>();
            services.AddTransient<IUserProvider, UserProvider>();
            services.AddTransient<ITransactionProvider, TransactionProvider>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowAll");
            var routeBuilder = new RouteBuilder(app);

            app.UseDefaultFiles();
            app.UseMvc();

            routeBuilder.MapRoute("{controller}/{action}",
                async context => {
                    context.Response.ContentType = "text/html; charset=utf-8";
                });


            routeBuilder.MapRoute("{controller}/{action}/{id}",
                async context => {
                    context.Response.ContentType = "text/html; charset=utf-8";
                });

            app.UseRouter(routeBuilder.Build());
          
        }
    }
}
