using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SMEntities;
using System.ComponentModel.DataAnnotations;

namespace firstConsole
{

  
public    class Program_Day10_Part1
    {

        public static dynamic GetDefaultValue(Type t)
        {
            if (t.IsValueType)
                return Activator.CreateInstance(t);

            return null;
        }
        public static dynamic ChangeType(string value, string type)
        {
            Type ty = Type.GetType(type);
            try
            {
                Type t = Nullable.GetUnderlyingType(ty) ?? ty;

                return Convert.ChangeType(value, t);
            }

            catch (Exception ex)
            {

                return GetDefaultValue(ty);
            }


        }


        public static void ModelBinder<T>(T model, Dictionary<string, string> dct, Dictionary<string, Dictionary<string, string>> error)
        {
            var type = model.GetType();
            var properties = type.GetProperties();
            foreach (var item in properties)
            {

                Dictionary<string, string> ErrorItem = new Dictionary<string, string>();
                var key = item.Name.ToLower();
                if (dct.ContainsKey(key))
                {

                    var attr = item.GetCustomAttributes(true);

                    foreach (var iat in attr)
                    {
                        if (iat is ValidationAttribute)
                        {
                            var iatt = iat as ValidationAttribute;
                            bool b = iatt.IsValid(dct[key]);
                            if (!b)
                            {
                                ErrorItem.Add(iatt.GetType().Name, iatt.FormatErrorMessage(key));

                            }
                        }
                    }

                    if (ErrorItem.Count > 0)
                    {
                        Dictionary<string, string> dcte = new Dictionary<string, string>();
                        error.Add(key, dcte);
                        foreach (var itemE in ErrorItem.Keys)
                        {
                            dcte.Add(itemE, ErrorItem[itemE]);
                        }

                        continue;
                    }


                    item.SetValue(model, ChangeType(dct[key], item.PropertyType.FullName));
                }

            }


            var attrClass = model.GetType().GetCustomAttributes(true);
            foreach (var iat in attrClass)
            {

            }
        }



        public static dynamic Id { get; set; } //class 
        public static void Main_10(string[] arg)
        {

            Dictionary<string, string> dct = new Dictionary<string, string>();
            dct.Add("id", "1");
            dct.Add("age", "25");

            dct.Add("agevalue", "26");
            dct.Add("firstname", "Ka");
            dct.Add("lastname", "a");
            dct.Add("address", "magarpatta");

            Student s = new Student();
            Dictionary<string, Dictionary<string, string>> error = new Dictionary<string, Dictionary<string, string>>();
            ModelBinder(s, dct, error);

            Console.ReadLine();  
        }

       
    }
}
