using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SMEntities
{

       
    [Table("TblStudent")]
    public class Student : ISubject
    {

        [Key]
        public int Id { get; set; }



        [MinLength(3)]
        [Required]
        [RegularExpression(pattern: "[A-Za-z]{2,30}")]
        public string FirstName { get; set; }


       
        [MinLength(3)]
        [Required]
        [RegularExpression(pattern: "[A-Za-z]{2,30}")]
        public string LastName { get; set; }


        [Column(name:"StudentAge")]
        public decimal Age { get; set; }


        [NotMapped]
        public string Subject { get; set; }

        public int SubjectId { get; set; }

        [NotMapped]
        public string Doj { get; set; }


        [Column(name:"DOJ", TypeName ="DateTime")]
        public DateTime StudentDoj { get; set; }

        public decimal Fees { get; set; }

        public virtual Subject Subjects { get; set; }
    }

    public interface ISubject
    {
         Subject Subjects { get; set; }
        public int SubjectId { get; set; }
    }
}
