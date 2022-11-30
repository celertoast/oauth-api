using System;
using System.Collections.Generic;
using System.Linq;

namespace firstConsole
{


   // public delegate bool MyCondition2<T>(T intVal);

    public class MyLinqExt
    {
        public static List<T> GetCollection<T>(IEnumerable<T> arr, MyCondition2<T> myCondition)
        {
            List<T> stu = new List<T>();
            foreach (var item in arr)
            {
                if (myCondition(item))
                {
                    stu.Add(item);
                }
            }

            //int j = 0;
            //for (int i = 0; i < 5; i = i + 1)
            //{

            //    if (myCondition(arr[i]))
            //    {
            //        stu.Add(arr[i]);
            //        j = j + 1;
            //    }


            //}

            return stu;
        }

    }
    class Program_ThirdDat_Part3
    {

      

        public delegate bool MyCondition(string str, char c);
       public static void Main_Part3(string[] args)
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



            //   Employee[] arr = empArr.Where((Employee e) => e.Id > 3 && !e.Name.Contains("A", StringComparison.OrdinalIgnoreCase)).ToArray();

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

            int[] arr = MyLinqExt2.GetCollection(arrInt, x => x > 2).ToArray();

            string[] arrE2 = MyLinqExt2.GetCollection(students, x => x.Contains("R")).ToArray();

            PrintStringArray(arr);

            PrintStringArray(arrE2);
            //   Console.WriteLine(isOk);
          //  PrintStringArray(empArr);
            Console.ReadLine();
 

        }

        public  static void PrintStringArray<T>(T[] stus)
        {

            for (int i = 0; i < stus.Length; i = i + 1)
            {                
                    Console.WriteLine(stus[i]);
                
            }
        }



     


     
    }
}
