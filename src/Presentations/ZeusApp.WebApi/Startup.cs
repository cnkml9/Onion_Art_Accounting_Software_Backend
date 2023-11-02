using ZeusApp.Application.Extensions;
using ZeusApp.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ZeusApp.WebApi.Middlewares;
using ZeusApp.WebApi.Extensions;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text.Json;

namespace ZeusApp.WebApi;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IConfiguration _configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplicationLayer();
        services.AddContextInfrastructure(_configuration);
        services.AddPersistenceContexts(_configuration);
        services.AddRepositories();
        services.AddSharedInfrastructure(_configuration);
        services.AddEssentials();
        services.AddControllers(options =>
        {
            //options.OutputFormatters.RemoveType<SystemTextJsonOutputFormatter>();
            //options.OutputFormatters.Add(new SystemTextJsonOutputFormatter(new JsonSerializerOptions(JsonSerializerDefaults.Web)
            //{
            //    MaxDepth = 100,
            //  
            //}));
        }).AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });


        services.AddCors();

        services.AddMvc(o =>
        {
            var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            o.Filters.Add(new AuthorizeFilter(policy));
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }


        app.ConfigureSwagger();
        app.UseHttpsRedirection();

        if (!env.IsDevelopment())
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseCors(x => x
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true) // allow any origin
            .AllowCredentials());

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
