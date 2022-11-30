using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SMEntities
{

    public class ValidateLastName : CompareAttribute
    {

        public ValidateLastName(string name) : base(name)
        {

        }
        public override bool IsValid(object value)
        {
            var str = value.ToString();
            if (str.Length == 20)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
    public class Validate : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            var str = value.ToString();
            if (str.Length == 20)
            {
                return true;
            } else
            {
                return false;
            }
            
        }
    }
}
