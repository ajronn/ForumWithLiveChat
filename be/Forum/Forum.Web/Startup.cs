using Forum.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Forum.Domain.Interface.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Forum.Domain.Implementation.Repository;
using Forum.Domain.Implementation.Service;
using Forum.Domain.Interface.Service;
using Forum.Handler;
using Forum.Transfer.Section.Query;

namespace Forum.Web
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
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<ForumDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ISectionRepository, SectionRepository>();
            services.AddScoped<ISubsectionRepository, SubsectionRepository>();
            services.AddScoped<IThreadRepository, ThreadRepository>();
            services.AddScoped<IPostRepository, PostRepository>();

            services.AddScoped<ISectionService, SectionService>();
            services.AddScoped<ISubsectionService, SubsectionService>();
            services.AddScoped<IThreadService, ThreadService>();
            services.AddScoped<IPostService, PostService>();

            services.RegisterRequestHandlers();
            services.RegisterMapping();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Forum.Web", Version = "v1" });
            });

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Forum.Web v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
