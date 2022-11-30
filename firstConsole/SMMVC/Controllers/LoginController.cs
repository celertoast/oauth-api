using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SMServices;
using SMUtilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SMMVC.Controllers
{
    public class LoginController : Controller
    {
        public LoginService LoginService { get; set; }
        public LoginController(LoginService loginService)
        {
            LoginService = loginService;
        }
        public IActionResult Index()
        {

             
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
           var claimsPrincipal = LoginService.GetLoginUserClaimsPrincipal(userName, password);

           

          if (claimsPrincipal is null)
          {
                ViewBag.message = "UserName/password is not valid";
                return View("Index");
          }
            if (Contants.isCookie)
            {
               // HttpContext.Response.Cookies.Append("", "");
                await HttpContext.SignInAsync(Contants.AuthenticationScheme, claimsPrincipal);
                HttpContext.User = claimsPrincipal;

            } else
            {
                using (MemoryStream ms = new MemoryStream())
                {
                     
                    BinaryWriter binaryWriter = new BinaryWriter(ms);
                    claimsPrincipal.WriteTo(binaryWriter);
                    var bytes = ms.ToArray();
                    HttpContext.Session.Set("claimsPrincipal", bytes);
                }
                   

             //   var bytes = Convertor.ObectToByteArray(claimsPrincipal.Identities.FirstOrDefault());
             //   HttpContext.Session.Set("claimsPrincipal", bytes);
            }
            return Redirect("/");
        }
    }
}
