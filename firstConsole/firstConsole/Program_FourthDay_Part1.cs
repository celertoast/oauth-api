using System;
using System.Collections.Generic;
using System.Text;

namespace firstConsole
{
 public   class Program_FourthDay_Part1
    {

        public static void Main_Part1(string[] args)
        {

            Employee emp = new Employee()
            {
                Id = 1,
                Name = "Kavita",
                LastName="F"
            };

            //Person emp = new Person()
            //{
            //    Id = 2,
            //    Name = "Paritosh",
            //    LastName="M"
            //};
            

            string strData=    System.IO.File.ReadAllText(@"D:\abhay\kavita\kavitamvcclass\firstConsole\firstConsole\EmployeeTemplate.html");
            strData= strData.Replace("@Model.Id", emp.Id.ToString());
            strData = strData.Replace("@Model.Name", emp.Name.ToString());
            strData = strData.Replace("@Model.LastName", emp.LastName.ToString());
            System.IO.File.WriteAllText(@"D:\abhay\kavita\kavitamvcclass\firstConsole\firstConsole\Employee.html", strData);

            Console.WriteLine("Hi");
            Console.ReadLine(); ;
        }
    }
}
