using System;
using System.Linq;

namespace firstConsole
{
    class Program_SecondPart4
    {

        public delegate bool MyCondition2<T>(T intVal);

        public delegate bool MyCondition(string str, char c);
       public static void Main_Part4(string[] args)
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
            Employee[] arr = empArr.Where((e) => e.Id > 3 && !e.Name.Contains("A", StringComparison.OrdinalIgnoreCase)).ToArray();

            

            //   Console.WriteLine(isOk);
            PrintStringArray(empArr);
            Console.ReadLine();
 

        }

        public  static void PrintStringArray<T>(T[] stus)
        {

            for (int i = 0; i < stus.Length; i = i + 1)
            {
                if (stus[i] != null)
                {
                    Console.WriteLine(stus[i]);
                }
            }
        }



        public static T[] GetCollection<T>(T[] arr, MyCondition2<T> myCondition)
        {
            T[] stu = new T[arr.Length];
            int j = 0;
            for (int i = 0; i < 5; i = i + 1)
            {

                if (myCondition(arr[i]))
                {
                    stu[j] = arr[i];
                    j = j + 1;
                }


            }
            return stu;
        }



        public static string[] GetCollection(string[] students,char c, MyCondition myCondition)
        {
            string[] stu = new string[students.Length];
            int j = 0;
            for (int i = 0; i < 5; i = i + 1)
            {
                
                    if (myCondition(students[i], c))
                    {
                        stu[j] = students[i];
                        j = j + 1;
                    }
                 

            }
            return stu;
        }



        public static string[] GetCollection(string[] students, char c, string condition)
        {
            string[] stu = new string[students.Length];
            int j = 0;
            for (int i = 0; i < 5; i = i + 1)
            {
                if (condition.Equals("Containts"))
                {
                    if (Containts(students[i], c))
                    {

                        stu[j] = students[i];
                        j = j + 1;
                    }
                } else if (condition.Equals("StartWith"))
                {
                    if (StartWith(students[i], c))
                    {

                        stu[j] = students[i];
                        j = j + 1;
                    }
                }
                else if (condition.Equals("EndWith"))
                {
                    if (EndWith(students[i], c))
                    {

                        stu[j] = students[i];
                        j = j + 1;
                    }
                }

            }
            return stu;
        }

       


        public static bool Containts(string name, char c)
        {
            if (name.Contains(c))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static bool StartWith(string name, char c)
        {
            if (name.StartsWith(c))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public static bool EndWith(string name, char c)
        {
            if (name.EndsWith(c))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public static void Print321StarUsingDoubleForLoop()
        {
            for(int j = 3; j >= 1; j = j - 1)
            {
                for (int i = 1; i <= j; i = i + 1)
                {
                    Console.Write("*");
                }
                Console.WriteLine("");
            }
        }

        public static void Print123StarUsingForLoop()
        {
            for(int j = 1; j <= 3; j = j + 1)
            {
                for (int i = 1; i <= j; i = i + 1)
                {
                    Console.Write("*");
                }
                Console.WriteLine("");
            }
        }


        public static void Print321StarUsingForLoop()
        {
           
            
           for(int i = 1; i <= 3; i = i + 1)
            {
                Console.Write("*");
            }         
            Console.WriteLine("");


            for (int i = 1; i <= 2; i = i + 1)
            {
                Console.Write("*");
            }
            Console.WriteLine("");

            for (int i = 1; i <= 1; i = i + 1)
            {
                Console.Write("*");
            }
            Console.WriteLine("");


        }

        public static void Print321Star()
        {
            Console.WriteLine("***");
            Console.WriteLine("**");
            Console.WriteLine("*");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns></returns>
        public static bool CheckProductCodeCharWithoutSplaceLeftRightLength6(string productCode)
        {
            if (productCode.Trim().Length == 6)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public static  bool CheckProductCodeCharLength6(string productCode)
        {
            if (productCode.Length == 6)
            {
                return true;
            } else
            {
                return false;
            }

        }
    }
}
