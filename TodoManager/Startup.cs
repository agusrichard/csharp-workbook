using System;
using System.Linq;
using System.Net.Mime;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TodoManager.Models;
using TodoManager.Repositories;
using TodoManager.Settings;

namespace TodoManager
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

            // var mongoDbSettings = Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
            // mongoDbSettings.Username = Environment.GetEnvironmentVariable("MONGO_INITDB_ROOT_USERNAME");
            // mongoDbSettings.Password = Environment.GetEnvironmentVariable("MONGO_INITDB_ROOT_PASSWORD");
            // mongoDbSettings.Host = Environment.GetEnvironmentVariable("MONGODB_HOST");
            // mongoDbSettings.Port = Convert.ToInt16(Environment.GetEnvironmentVariable("MONGODB_PORT"));

            // BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            // BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));
            // services.AddSingleton<IMongoClient>(serviceProvider =>
            // {
            //     return new MongoClient(mongoDbSettings.ConnectionString);
            // });
            // services.AddSingleton<ITodoRepository, MongoDbTodoRepository>();

            // services.AddHealthChecks()
            //     .AddMongoDb(
            //         mongoDbSettings.ConnectionString,
            //         name: "mongodb",
            //         timeout: TimeSpan.FromSeconds(3),
            //         tags: new[] { "ready" });

            var dbSettings = Configuration.GetSection(nameof(DbSettings)).Get<DbSettings>();

            services.AddDbContext<TodoContext>(opt =>
            {
                opt.UseSqlServer(dbSettings.DbConnectionString);
            });
            services.AddScoped<ITodoRepository, SqlServerTodoRepository>();

            services.AddControllers(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TodoManager", Version = "v1" });
            });

            services.AddHealthChecks()
                .AddSqlServer(
                    dbSettings.DbConnectionString,
                    name: "sqlserver",
                    timeout: TimeSpan.FromSeconds(3),
                    tags: new[] { "ready" }
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoManager v1"));
                app.UseHttpsRedirection();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapHealthChecks("/health/ready", new HealthCheckOptions
                {
                    Predicate = (check) => check.Tags.Contains("ready"),
                    ResponseWriter = async (context, report) =>
                    {
                        var result = JsonSerializer.Serialize(
                            new
                            {
                                status = report.Status.ToString(),
                                checks = report.Entries.Select(entry => new
                                {
                                    name = entry.Key,
                                    status = entry.Value.Status.ToString(),
                                    exception = entry.Value.Exception != null ? entry.Value.Exception.Message : "none",
                                    duration = entry.Value.Duration.ToString()
                                })
                            }
                        );

                        context.Response.ContentType = MediaTypeNames.Application.Json;
                        await context.Response.WriteAsync(result);
                    }
                });

                endpoints.MapHealthChecks("/health/live", new HealthCheckOptions
                {
                    Predicate = (_) => false
                });
            });
        }
    }
}
