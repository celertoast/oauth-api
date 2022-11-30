using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SMEntities;
using SMServices;
using SMUtilities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMVC.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public LoginService LoginService { get; set; }
        public LoginController(LoginService loginService)
        {
            LoginService = loginService;
        }



        [HttpPost]
        [Route("login2")]
        public async Task<IActionResult> Login2(LoginUser loginUser)
        {
            var claimsPrincipal = LoginService.GetLoginUserClaimsPrincipal(loginUser.Name, loginUser.Password);

            if (claimsPrincipal is null)
            {

                return Ok("User Name/Password is not matched");
            }

            using (MemoryStream ms = new MemoryStream())
            {

                BinaryWriter binaryWriter = new BinaryWriter(ms);
                claimsPrincipal.WriteTo(binaryWriter);
                var bytes = ms.ToArray();
                

                var token = Convert.ToBase64String(bytes);
                //Encrypt
                var encToken = token;

                return Ok(encToken);
            }

           // return Ok("User Name/Password is not matched");
        }



        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            var claimIdentity = LoginService.GetLoginUserClaimsIdentity(loginUser.Name, loginUser.Password);

            if (claimIdentity is null)
            {

                return Ok("User Name/Password is not matched");
            }

            var sck = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("1234567890123456"));
            var std = new SecurityTokenDescriptor
            {
                Subject= claimIdentity,
                SigningCredentials=new SigningCredentials(sck,SecurityAlgorithms.HmacSha256Signature),
                Expires=DateTime.Now.AddDays(1)
            };

            var jwt = new JwtSecurityTokenHandler();
            var token = jwt.CreateToken(std);
            var tokenStr = jwt.WriteToken(token);
            return Ok(tokenStr);
        }

    }
}

