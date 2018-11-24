using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wagner_DAmaral_Assignment01.Models;

namespace Wagner_DAmaral_Assignment01
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:RecipeBookRecipes:ConnectionString"]));
            services.AddTransient<IRecipeRepository, EFRecipeRepository>();
            services.AddTransient<IReviewRepository, EFReviewRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc();
            services.AddMemoryCache();
            //services.AddSession();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            //app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new {controller = "Home", action = "Index" }
                    );

                routes.MapRoute(
                    name: null,
                    template: "Recipes",
                    defaults: new { controller = "Recipe", action = "DataPage" }
                    );

                routes.MapRoute(
                    name: null,
                    template: "Recipes/{RecipeID:int?}",
                    defaults: new { controller = "Recipe", action = "DisplayPage" }
                    );


                routes.MapRoute(
                    name: null,
                    template: "Recipes/New",
                    defaults: new { controller = "Recipe", action = "New" }
                    );

                routes.MapRoute(
                    name: null,
                    template: "Recipes/Edit/{RecipeId:int?}",
                    defaults: new { controller = "Recipe", action = "Edit" }
                    );

                routes.MapRoute(
                    name: null,
                    template: "Recipes/Delete/{RecipeId:int}",
                    defaults: new { controller = "Recipe", action = "Delete" }
                    );

                routes.MapRoute(
                    name: null,
                    template: "Login",
                    defaults: new { controller = "Home", action = "UserPage" }
                    );

                

                routes.MapRoute(
                    name: null,
                    template: "Recipes/Admin",
                    defaults: new { controller = "Review", action = "Admin" }
                    );

                routes.MapRoute(
                    name: null,
                    template: "Recipes/{RecipeId:int}/AddReview",
                    defaults: new { controller = "Review", action = "AddReview" }
                    );

                routes.MapRoute(name: null, template: "Recipes/{action}/{id?}");
                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
            });
            SeedData.EnsurePopulated(app);
        }
    }
}
