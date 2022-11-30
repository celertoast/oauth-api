using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SMDBContext;
using SMRepository;
using SMServices;
using SMUtilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SMMVC
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
            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();


            services.AddScoped<LoginRepository, LoginRepository>();
            services.AddScoped<LoginService, LoginService>();
            services.AddScoped<KpmDbContext, KpmDbContext>();
            services.AddScoped<SubjectRepository, SubjectRepository>();
            services.AddScoped<SubjectService, SubjectService>();
            services.AddScoped<StudentRepository, StudentRepository>();
            services.AddScoped<StudentService, StudentService>();

         if (Contants.isCookie)
            {
                services.AddAuthentication(Contants.AuthenticationScheme).AddCookie(Contants.AuthenticationScheme, x =>
                {
                    x.LoginPath = "/Login/index";
                    x.LogoutPath = "/Login/index";
                    x.AccessDeniedPath = "/Unauth/index";
                    x.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                    x.SlidingExpiration = true;

                });

            }


            services.AddSession(x=> {
                x.IdleTimeout = TimeSpan.FromMinutes(20);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();

            app.UseAuthentication();

            app.Use(async (context, next) =>
            {
                if (Contants.isCookie)
                {
                    await next();
                    return;
                }
                var url = context.Request.Path.ToString();

            if (url.StartsWith("/login"))
                {
                    await next();
                }else
                {
                    byte[] bytes;
                    context.Session.TryGetValue("claimsPrincipal", out bytes);
                    if (bytes is null)
                    {
                        context.Response.Redirect("/login");
                    } else
                    {
                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            BinaryReader binary = new BinaryReader(ms);
                           // binary.ReadBytes(bytes.Length);
                            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(binary);
                            context.User = claimsPrincipal;
                        }

                           
                        
                        
                        await next();
                    }
                }
                

               
            });

            //app.Use(async (context,next) =>
            //{
            //    try
            //    {

                    
            //        await next();
            //    }
            //    catch (Exception ex)
            //    {
            //        await context.Response.WriteAsync(ex.StackTrace.ToString());
            //    }
                

            //});

            //app.Map("/fis", (app) =>
            //{
            //    app.Run(async (context) =>
            //    {
            //        await context.Response.WriteAsync("I am in run");
            //    });
            //});

            //app.Run(async (context) =>
            //{
            //     await context.Response.WriteAsync("I am in run");
            //});


            //app.Use(async (context, next) =>
            //{

            //    throw new Exception("I am in xxx");

            //});





            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                // endpoints.MapControllerRoute(
                //name: "Selenium",
                //pattern: "Selenium/{controller=Student}/{action=List}/{id?}");



                // endpoints.MapControllerRoute(
                //  name: "MVC",
                //  pattern: "MVC/{controller=Student}/{action=List}/{id?}");


                endpoints.MapControllerRoute(
                   name: "login",
                   pattern: "login/{action=index}/{controller=Login}/{id?}");


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Student}/{action=List}/{id?}");
            });
        }
    }
}
