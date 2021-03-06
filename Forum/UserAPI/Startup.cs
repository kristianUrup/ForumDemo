using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SharedModels;
using UserAPI.Repository;
using UserAPI.Service;
using UserAPI.Service.Implementation;
using UserAPI.Service.Messaging;

namespace UserAPI
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
            services.AddDbContext<UserApiContext>(opt => opt.UseSqlite("Data Source=UserDatabase.db"));

            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "UserAPI", Version = "v1"}); });
            
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            
            services.AddScoped<IMessagePublisher, MessagePublisher>((s => 
            {
                var connectionString = Configuration.GetConnectionString("RabbitMQConnectionString");
                return new MessagePublisher(connectionString);
            }));

            services.AddTransient<IDbInitializer, DbInitializer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserAPI v1"));
            }


            // Initialize the database
            using (var scope = app.ApplicationServices.CreateScope())
            {
                // Initialize the database
                var services = scope.ServiceProvider;
                var dbContext = services.GetService<UserApiContext>();
                var dbInitializer = services.GetService<IDbInitializer>();
                dbInitializer.InitializeDatabase(dbContext);
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}