using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using System.Text;

namespace SMEntities
{
    [Serializable]
    [Table("TblUserLogin")]
    public class LoginUser : IIdentity
    {


        [Key]
        public int Id { get; set; }

        [NotMapped]
        public string AuthenticationType { get; set; }


        [NotMapped]
        public bool IsAuthenticated { get; set; }

        [Column(name:"UserName")]
        public string Name { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }




    }
}
