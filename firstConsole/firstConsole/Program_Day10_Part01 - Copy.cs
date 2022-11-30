using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SMEntities;
using System.ComponentModel.DataAnnotations;
using SMDBContext;
using Microsoft.EntityFrameworkCore;
using SMRepository;

namespace firstConsole
{

  
public    class Program_Day11_Part1
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
        public static void Main(string[] arg)
        {
            int k = 0;
            KpmDbContext kpm = new KpmDbContext();
            StudentRepository studentRepository = new StudentRepository(kpm);
            var search = new SMModels.StudentSearch();
            search.FirstNameText = "A";
            search.Page.CurrentPage = 2;
        var StudentList=    studentRepository.GetStudentList(search);
             var subjectList = kpm.Subjects.Skip(2).Take(3).ToList();
           
            //  StudentList = kpm.Students.ToList();




            Console.ReadLine();  
        }

       
    }
}
