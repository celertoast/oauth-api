using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace firstConsole
{
    class Program_ThirdDat_Part5
    {
        public static void Main_Part5(string[] args)
        {

            Employee emp = new Employee
            {
                Id = 1,
                Name = "Abhay"
            };


            Employee emp2 = new Employee
            {
                Id = 1,
                Name = "Ajay"
            };



            int a = (int)1.0F;
            if (emp.Equals(2))
            {
                Console.WriteLine(emp.ToString());
            }
            
            foreach (var item in "ABhayVelankar")
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(emp.ToString());

          //  List<Employee> empList = new List<Employee>();

            List<int> lstInt = new List<int>(1000000);
            //int[] arrInt = new int[6];

            Hashtable ht = new Hashtable();
             for(int i = 0; i < 1000000; i = i + 1)
            {

                lstInt.Add(i.GetHashCode());
                ht.Add(0, 0);
            }
            //  arrInt[7] = 2;
            // Console.WriteLine(emp.GetType());

            //  Console.WriteLine(emp.GetHashCode());

            Console.ReadLine();
            


        }
    }
}
