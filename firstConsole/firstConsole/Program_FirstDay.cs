using System;
//using System.Linq;

namespace firstConsole
{
    class Program_FirstDay
    {
        static void Main_FirstDat(string[] args)
        {

            //string 
            //collection 
            //date
            //number 
            //boolean 

            //string st1 = "KC";
            //string st2 = "AV";
            //string st3 = "sf";
            //string st4 = "xt";
            //string st5 = "zx";

            string[] students = new string[5]
            {
                "Kavita",
                "Abhay",
                "Sawan",
                "Sandeep",
                "Ritesh"
            };

            //   string[] stus = StartWithCollection(students, 'A');

            //   string[] stus = ContaintsCollection(students, 'a');

            // string[] stus = EndWithCollection(students, 'a');

            string[] stus = GetCollection(students, 'a', "Containts");

            PrintStringArray(stus);
            Console.ReadLine();

            //if (StartWithA(st2))
            //{
            //    Console.WriteLine(st2);
            //}

            //if (StartWithA(st3))
            //{
            //    Console.WriteLine(st3);
            //}


            //if (StartWithA(st4))
            //{
            //    Console.WriteLine(st4);
            //}

            //if (StartWithA(st5))
            //{
            //    Console.WriteLine(st5);
            //}






            //  Console.ReadLine();

            //   Print123StarUsingForLoop();
            //   Print321StarUsingDoubleForLoop();
            ////  Print321StarUsingForLoop();

            //   // Print321Star();
            //   string name = "Abhay Velankar";



            //   name = name.Trim();
            //   name = name.ToLower();

            //   Console.WriteLine(name);

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

        public static string[] ContaintsCollection(string[] students, char c)
        {
            string[] stu = new string[students.Length];
            int j = 0;
            for (int i = 0; i < 5; i = i + 1)
            {
                if (Containts(students[i], c))
                {
                    
                    stu[j] = students[i];
                    j = j + 1;
                }
            }
            return stu;
        }


        public static string[] EndWithCollection(string[] students, char c)
        {
            string[] stu = new string[students.Length];
            int j = 0;
            for (int i = 0; i < 5; i = i + 1)
            {
                if (EndWith(students[i], c))
                {
                    stu[j] = students[i];
                    j = j + 1;
                }
            }
            return stu;
        }

        public static string[] StartWithCollection(string[] students, char c)
        {
            string[] stu = new string[students.Length];
            int j = 0;
            for (int i = 0; i < 5; i = i + 1)
            {
                if (StartWith(students[i], c))
                {
                    stu[j] = students[i];
                    j = j + 1;
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
