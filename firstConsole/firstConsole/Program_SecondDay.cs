using System;
//using System.Linq;

namespace firstConsole
{
    class Program_SecondDay
    {

        public delegate bool MyCondition2(string str);

        public delegate bool MyCondition(string str, char c);
       public static void Main2(string[] args)
        {

           

            string[] students = new string[5]
            {
                "Kavita",
                "Abhay",
                "Sawan",
                "Sandeep",
                "Ritesh"
            };



            // string[] stus = GetCollection(students, 'a', "Containts");
            //  string[] stus = GetCollection(students, 'a', Program.EndWith);
            // string[] stus = GetCollection(students, 'A', (string s, char c)=> s.StartsWith(c));
            string[] stus = GetCollection(students,(string s) => s.Contains("a"));
            PrintStringArray(stus);
            Console.ReadLine();
 

        }

        public  static void PrintStringArray(string[] stus)
        {

            for (int i = 0; i < stus.Length; i = i + 1)
            {
                if (stus[i] != null)
                {
                    Console.WriteLine(stus[i]);
                }
            }
        }



        public static string[] GetCollection(string[] arr, MyCondition2 myCondition)
        {
            string[] stu = new string[arr.Length];
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
