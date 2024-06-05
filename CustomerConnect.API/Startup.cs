using CustomerConnect.Application.Extensions;
using Microsoft.OpenApi.Models;
using CustomerConnect.Infrastructure.Mappers;
using CustomerConnect.Application.Interfaces;
using CustomerConnect.Application.Services;

namespace CustomerConnect.API
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

            services.AddControllers();

            services.AddCors();

            services.RegisterRepositories(Configuration);

            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IPhoneService, PhoneService>();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CustomerConnect.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CustomerConnect.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(cors => cors.AllowAnyHeader()
                                    .AllowAnyMethod()
                                    .AllowAnyOrigin()
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}