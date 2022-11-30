using System;
using System.Collections.Generic;
using System.Text;

namespace firstConsole
{
   public class Person
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public float Age { get; set; }

        public decimal AgeValue { get; set; }
        public override bool Equals(Object obj)
        {
            if(!(obj is Employee))
            {
                return false;
            }

            var e = obj as Employee;
            if (this.Id == e.Id)
            {
                return true;
            }
            return false;
            
        }
        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}
