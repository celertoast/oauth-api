using SMDBContext;
using SMEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMRepository
{
    public class LoginRepository
    {

        public KpmDbContext KpmDbContext { get; set; }
        public LoginRepository(KpmDbContext kpmDbContext)
        {
            KpmDbContext = kpmDbContext;
        }


        public LoginUser GetLoginUser(string userName)
        {
         var loginUser=   KpmDbContext.LoginUsers.FirstOrDefault(x=> x.Name==userName);
            return loginUser;
        }
    }
}
