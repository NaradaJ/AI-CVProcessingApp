using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AIProcessingService.Data;
using AIProcessingService.Services;
using Microsoft.AspNetCore.Hosting;


namespace AIProcessingService
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AppDbContext>();
            services.AddScoped<CVSummarizationService>();
            services.AddScoped<TechStackHighlightService>();
            services.AddScoped<VectorStorageService>();
            services.AddControllers();
            services.AddScoped<OpenAIService>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
