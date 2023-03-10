using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using APBD_zad7.Services;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace APBD_zad7
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
            services.AddDbContext<Models.DatabaseContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultDatabaseConnection"));
            });
            services.AddScoped<IDBService, DbService>();
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddControllers();

            void SetupAction(SwaggerGenOptions c)
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "trips", Version = "v1" });
            }

            services.AddSwaggerGen(SetupAction);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "trips v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}