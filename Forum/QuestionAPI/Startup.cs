using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using QuestionAPI.Repository;
using QuestionAPI.Repository.Implementation;
using QuestionAPI.Service;
using QuestionAPI.Service.Implementation;
using UserAPI.Repository;

namespace QuestionAPI
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
            services.AddDbContext<QuestionApiContext>(opt => opt.UseSqlite("Data Source=QuestionDatabase.db"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "QuestionAPI", Version = "v1"});
            });

            services.AddScoped<IRepository<Question>, QuestionRepository>();
            services.AddScoped<IQuestionService, QuestionService>();
            

            services.AddTransient<IDbInitializer, DbInitializer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "QuestionAPI v1"));
            }

            // Initialize the database
            using (var scope = app.ApplicationServices.CreateScope())
            {
                // Initialize the database
                var services = scope.ServiceProvider;
                var dbContext = services.GetService<QuestionApiContext>();
                var dbInitializer = services.GetService<IDbInitializer>();
                dbInitializer.InitializeDatabase(dbContext);
            }
            
            Task.Factory.StartNew(() => {
                var connectionString = Configuration.GetConnectionString("RabbitMQConnectionString");
                new MessageListener(app.ApplicationServices, connectionString).Start();
            });

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}