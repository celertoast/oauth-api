using System;
using System.Linq;

namespace firstConsole
{
    class Program_ThirdDat_Part41
    {
        
        
        
        public delegate bool MyCondition(string str, char c);
       public static void Main_Part5(string[] args)
        {



            Employee[] empArr = new Employee[5];
            empArr[0] = new Employee
            {
                Id = 1,
                Name = "Abhay"
            };

            empArr[1] = new Employee
            {
                Id = 2,
                Name = "Kavita"
            };

            empArr[2] = new Employee
            {
                Id = 3,
                Name = "Sawan"
            };

            empArr[3] = new Employee
            {
                Id = 4,
                Name = "Sandeep"
            };

            empArr[4] = new Employee
            {
                Id = 5,
                Name = "Ritesh"
            };



               Employee[] arr44 = empArr.Where((Employee e) => e.Id > 3 && !e.Name.Contains("A", StringComparison.OrdinalIgnoreCase)).ToArray();


               Employee[] arr23 = Enumerable.Where(empArr, (Employee e) => e.Id > 3 && !e.Name.Contains("A", StringComparison.OrdinalIgnoreCase)).ToArray();

            //Employee[] arr = empArr.Where((e) => e.Id > 3).Where((e)=>!e.Name.Contains("A", StringComparison.OrdinalIgnoreCase)).ToArray();

            //Employee[] areE = MyLinqExt.GetCollection<Employee>(empArr, (e) => e.Id > 3).ToArray();
            //Employee[] areE2 = MyLinqExt.GetCollection<Employee>(empArr, (e)=> !e.Name.Contains("A", StringComparison.OrdinalIgnoreCase)).ToArray();

            int[] arrInt = new int[5]
             {
                1,
                2,
                3,
                4,
                5
             };


            string[] students = new string[5]
          {
                "Kavita",
                "Abhay",
                "Sawan",
                "Sandeep",
                "Ritesh"
          };

            //   int[] arr = MyLinqExt4.GetCollection(arrInt, x => x > 2).ToArray();

            ///int[] arrWhere= arrInt.Where(x => x > 2).ToArray();
            int[] arr = arrInt.GetCollection(x => x > 2).ToArray();
            int[] arr2 = MyLinqExt4.GetCollection(arrInt, x => x > 2).ToArray();
            string[] arrE2 = MyLinqExt4.GetCollection(students, x => x.Contains("R")).ToArray();

            arr.Print();
            arrE2.Print();

            //PrintStringArray(arr);

            //PrintStringArray(arrE2);
            //   Console.WriteLine(isOk);
          //  PrintStringArray(empArr);
            Console.ReadLine();
 

        }

       



     


     
    }
}
