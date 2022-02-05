using Microsoft.AspNetCore.Authentication.JwtBearer;
using MoviesApp.API.Filters;

namespace MoviesApp.API;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }


    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.Filters.Add(typeof(GlobalExceptionFilter));
        });
        services.AddEndpointsApiExplorer();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
        services.AddSwaggerGen();
        services.AddCors(options =>
        {    
           var frontEndUrl = Configuration.GetValue<string>("frontend_url");
           options.AddDefaultPolicy(builder =>
           {
               builder.WithOrigins(frontEndUrl).AllowAnyMethod().AllowAnyHeader();
           });
       });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors();
        app.UseAuthorization();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}