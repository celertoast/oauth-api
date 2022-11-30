using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SMEntities
{
  public  class Teacher
    {
        public int Id { get; set; }


        
      
        public string FirstName { get; set; }

        public string LastName { get; set; }


        public string ClassName { get; set; }
    }
}
