using System;
using System.Collections.Generic;
using System.Text;

namespace firstConsole
{
 public   class Program_FourthDay_Part3
    {

        public static void Main_Part3(string[] args)
        {

            Employee emp = new Employee()
            {
                Id = 2,
                Name = "Paritosh M",
                LastName = "M"
            };

            //Person emp = new Person()
            //{
            //    Id = 2,
            //    Name = "Paritosh",
            //    LastName = "M"
            //};


            //string strData=    System.IO.File.ReadAllText(EmployeeTemplate.html");
            //strData= strData.Replace("@Model.Id", emp.Id.ToString());
            //strData = strData.Replace("@Model.Name", emp.Name.ToString());
            //strData = strData.Replace("@Model.LastName", emp.LastName.ToString());
            //System.IO.File.WriteAllText(@"D:\abhay\kavita\kavitamvcclass\firstConsole\firstConsole\Employee.html", strData);


            //ViewPerson("EmployeeTemplate", emp, "Employee");
            //ViewPerson("EditTemplate", emp, "EmployeeEdit");

            View("EmployeeTemplate", emp, "Employee");
            View("EditTemplate", emp, "EmployeeEdit");

            //string strDataEdit = System.IO.File.ReadAllText(@"D:\abhay\kavita\kavitamvcclass\firstConsole\firstConsole\EditTemplate.html");
            //strDataEdit = strDataEdit.Replace("@Model.Id", emp.Id.ToString());
            //strDataEdit = strDataEdit.Replace("@Model.Name", emp.Name.ToString());
            //strDataEdit = strDataEdit.Replace("@Model.LastName", emp.LastName.ToString());
            //System.IO.File.WriteAllText(@"D:\abhay\kavita\kavitamvcclass\firstConsole\firstConsole\EmployeeEdit.html", strDataEdit);

            //Console.WriteLine("Hi");
            Console.ReadLine(); ;
        }


        public static void View<T>(string path, T model, string replacePath)
        {
            var pathInput = @"D:\abhay\kavita\kavitamvcclass\firstConsole\firstConsole\" + path + ".html";
            var pathOutput = @"D:\abhay\kavita\kavitamvcclass\firstConsole\firstConsole\" + replacePath + ".html";
            string strDataEdit = System.IO.File.ReadAllText(pathInput);
            var type = model.GetType();

            var properties = type.GetProperties();
            foreach (var item in properties)
            {
              //  Console.WriteLine(item.Name + item.GetValue(model, null));

                strDataEdit = strDataEdit.Replace("@Model." + item.Name, item.GetValue(model, null).ToString());
            }
            //strDataEdit = strDataEdit.Replace("@Model.Id", model.Id.ToString());
            //strDataEdit = strDataEdit.Replace("@Model.Name", model.Name.ToString());
            //strDataEdit = strDataEdit.Replace("@Model.LastName", model.LastName.ToString());
            System.IO.File.WriteAllText(pathOutput, strDataEdit);

        }



        public static void ViewEmployee(string path, Employee model, string replacePath)
        {
            var pathInput= @"D:\abhay\kavita\kavitamvcclass\firstConsole\firstConsole\"+ path+ ".html";
            var pathOutput = @"D:\abhay\kavita\kavitamvcclass\firstConsole\firstConsole\" + replacePath + ".html";
            string strDataEdit = System.IO.File.ReadAllText(pathInput);
            strDataEdit = strDataEdit.Replace("@Model.Id", model.Id.ToString());
            strDataEdit = strDataEdit.Replace("@Model.Name", model.Name.ToString());
            strDataEdit = strDataEdit.Replace("@Model.LastName", model.LastName.ToString());
            System.IO.File.WriteAllText(pathOutput, strDataEdit);

        }


        public static void ViewPerson(string path, Person model, string replacePath)
        {
            var pathInput = @"D:\abhay\kavita\kavitamvcclass\firstConsole\firstConsole\" + path + ".html";
            var pathOutput = @"D:\abhay\kavita\kavitamvcclass\firstConsole\firstConsole\" + replacePath + ".html";
            string strDataEdit = System.IO.File.ReadAllText(pathInput);
            strDataEdit = strDataEdit.Replace("@Model.Id", model.Id.ToString());
            strDataEdit = strDataEdit.Replace("@Model.Name", model.Name.ToString());
            strDataEdit = strDataEdit.Replace("@Model.LastName", model.LastName.ToString());
            System.IO.File.WriteAllText(pathOutput, strDataEdit);

        }
    }
}
