using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SMDBContext;
using SMRepository;
using SMServices;
using SMUtilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SMWebAPI
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
            services.AddControllers();
            services.AddScoped<LoginRepository, LoginRepository>();
            services.AddScoped<LoginService, LoginService>();

            services.AddScoped<KpmDbContext, KpmDbContext>();
            services.AddScoped<SubjectRepository, SubjectRepository>();
            services.AddScoped<SubjectService, SubjectService>();
            services.AddScoped<StudentRepository, StudentRepository>();
            services.AddScoped<StudentService, StudentService>();


            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, x =>
             {
                 x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                 {
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("1234567890123456")),
                     ValidateIssuer = false,
                     ValidateIssuerSigningKey =true,
                     ValidateAudience = false

                 };

                 x.Events = new JwtBearerEvents
                 {
                     OnMessageReceived = y =>
                     {
                         var str = y.Request.Query.FirstOrDefault(x=>x.Key=="token").Value.ToString();
                         if (string.IsNullOrWhiteSpace(str))
                         {
                             str = y.Request.Headers.FirstOrDefault(x => x.Key == "token").Value.ToString();
                         }

                         if (string.IsNullOrWhiteSpace(str))
                         {

                             y.NoResult();
                         } else
                         {
                             y.Token = str.Trim();
                         }
                        

                         return Task.CompletedTask;
                     }
                 };
 

             });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}


//app.Map("xxxx", async (context, next) =>
//{

//    var url = context.Request.Path.ToString();

//    if (url.StartsWith("/api/login"))
//    {
//        await next();
//    }
//    else
//    {


//        var header = context.Request.Headers.Where(x => x.Key == "token").FirstOrDefault();
//        var enctoken = header.Value;
//        //Decrypt
//        var token = enctoken;

//        if (string.IsNullOrWhiteSpace(token))
//        {
//            await next();
//            return;
//        }

//        byte[] bytes = Convert.FromBase64String(token);


//        if (bytes is null)
//        {
//            context.Response.Redirect("User is not authenticate");
//        }
//        else
//        {
//            using (MemoryStream ms = new MemoryStream(bytes))
//            {
//                BinaryReader binary = new BinaryReader(ms);
//                // binary.ReadBytes(bytes.Length);
//                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(binary);
//                context.User = claimsPrincipal;
//            }




//            await next();
//        }
//    }



//});
