using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using SMMVC.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SMMVC.Filters
{
    public class QdnAuthFilter : Attribute, IAuthorizationFilter
    {

        public string Claims { get; set; }

        public string Role { get; set; }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            ClaimsPrincipal user = context.HttpContext.User;

          if(!user.IsInRoleCheck(Role))
           {
                context.Result = new RedirectResult("/Unauth/index");
           }

        }


        
    }
}
