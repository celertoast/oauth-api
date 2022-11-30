using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SMEntities
{

    [Table("TblSubject")]
    public class Subject 
    {
        [Key]
        public int Id { get; set; }


        public string Name { get; set; }


       
    }
}
