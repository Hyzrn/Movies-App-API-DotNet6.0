using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using MoviesApp.API.APIBehaviour;
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
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddControllers(options =>
        {
            options.Filters.Add(typeof(GlobalExceptionFilter));
            options.Filters.Add(typeof(ParseBadRequest));
        }).ConfigureApiBehaviorOptions(BadRequestBehaviour.Parse);

        services.AddEndpointsApiExplorer();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
        services.AddSwaggerGen();
        services.AddCors(options =>
        {    
           var frontEndUrl = Configuration.GetValue<string>("FrontendUrl");
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