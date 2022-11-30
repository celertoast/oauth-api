using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SMMVC.Utility
{
    public static class CLamsPrisiplesExte
    {
        public static bool IsInRoleCheck(this ClaimsPrincipal user, string roles)
        {
            if (roles.Contains(","))
            {
                var roleArray = roles.Split(",").ToArray();
                var claim = user.Claims.Where(x => x.Type.ToLower() == "role").FirstOrDefault();

                if (claim is null)
                {
                    return false;
                }

                return roleArray.Contains(claim.Value);

            }

            var u = user.Claims.Where(x => x.Type.ToLower() == "role" && x.Value.ToLower() == roles.ToLower()).FirstOrDefault();
            if (u is null)
            {
                return false;
            }

            return true;
        }



        public static bool HasClaims(this ClaimsPrincipal user, string claims)
        {
            

            return true;
        }




    }
}
