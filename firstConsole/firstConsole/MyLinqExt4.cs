using System;
using System.Collections.Generic;

namespace firstConsole
{
    // public delegate bool MyCondition2<T>(T intVal);

    public static class MyLinqExt4
    {
        public static List<T> GetCollection<T>(this IEnumerable<T> arr, MyCondition2<T> myCondition)
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


        public static void Print<T>(this IEnumerable<T> stus)
        {

            foreach (var item in stus)
            {
                Console.WriteLine(item);
            }
             
        }


    }
}
