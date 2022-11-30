using System;
using System.Collections.Generic;
using System.Linq;

namespace firstConsole
{


    public delegate bool MyCondition2<T>(T intVal);

    public class MyLinqExt2
    {
        public static List<T> GetCollection<T>(T[] arr, MyCondition2<T> myCondition)
        {
            List<T> stu = new List<T>();
            int j = 0;
            for (int i = 0; i < arr.Length; i = i + 1)
            {

                if (myCondition(arr[i]))
                {
                    stu.Add(arr[i]);
                    j = j + 1;
                }


            }
            return stu;
        }

    }
    class Program_ThirdDat_Part2
    {

      

        public delegate bool MyCondition(string str, char c);
       public static void Main_Part2(string[] args)
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
          
            Employee[] arr = empArr.Where((e) => e.Id > 3).Where((e)=>!e.Name.Contains("A", StringComparison.OrdinalIgnoreCase)).ToArray();

            Employee[] areE = MyLinqExt2.GetCollection<Employee>(empArr, (e) => e.Id > 3).ToArray();
            Employee[] areE2 = MyLinqExt2.GetCollection<Employee>(empArr, (e)=> !e.Name.Contains("A", StringComparison.OrdinalIgnoreCase)).ToArray();

            PrintStringArray(arr);

            PrintStringArray(areE2);
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
