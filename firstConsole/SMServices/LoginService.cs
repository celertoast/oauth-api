using SMEntities;
using SMRepository;
using SMUtilities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace SMServices
{
   public class LoginService
    {

        public LoginRepository LoginRepository { get; set; }
        public LoginService (LoginRepository loginRepository)
        {
            LoginRepository = loginRepository;
        }


        public LoginUser GetLoginUser(string userName, string password)
        {
            var loginUser = LoginRepository.GetLoginUser(userName);
            if (string.Equals(password, loginUser.Password))
            {
                return loginUser;
            }  
            return null;
            
            
        }


        public ClaimsIdentity GetLoginUserClaimsIdentity(string userName, string password)
        {
            var loginUser = GetLoginUser(userName, password);
            if (loginUser is null)
            {
                return null;
            }
            loginUser.IsAuthenticated = true;
            loginUser.AuthenticationType = "cookies";
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(loginUser);
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, loginUser.Role));
            claimsIdentity.AddClaim(new Claim("Role", loginUser.Role));
            claimsIdentity.AddClaim(new Claim("Dept", "1"));

            claimsIdentity.AddClaim(new Claim("XYZ", "YTC"));

            
            return claimsIdentity;


        }




        public ClaimsPrincipal GetLoginUserClaimsPrincipal(string userName, string password)
        {
            var loginUser = GetLoginUser(userName, password);
            if (loginUser is null)
            {
                return null;
            }
            loginUser.IsAuthenticated = true;
            loginUser.AuthenticationType = "cookies";
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(loginUser);
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, loginUser.Role));
            claimsIdentity.AddClaim(new Claim("Role", loginUser.Role));
            claimsIdentity.AddClaim(new Claim("Dept" ,"1"));

            claimsIdentity.AddClaim(new Claim("XYZ", "YTC"));

            List<ClaimsIdentity> claimsIdentities = new List<ClaimsIdentity>();
            claimsIdentities.Add(claimsIdentity);

           // var bytes = Convertor.ObectToByteArray(claimsIdentities);
           // HttpContext.Session.Set("claimsPrincipal", bytes);


            //    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(loginUser);
            //   claimsPrincipal.AddIdentity(claimsIdentity);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentities);
            return claimsPrincipal;
            

        }


    }
}
