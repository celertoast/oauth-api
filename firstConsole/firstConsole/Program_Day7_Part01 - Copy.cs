using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace firstConsole
{

  
public    class Program_Day7_Part1
    {

        public static dynamic Id { get; set; } //class 
        public static void Main_Day07(string[] arg)
        {
            // var pr = new Program_Day6_Part1();

            var name = "Abhay Velankar";

            DistinctCharCountPrint(name);



           // Console.WriteLine(i);

            Console.ReadLine();  
        }

        public static void DistinctCharCountPrint(string str)
        {
            str = str.ToLower();
          var output=  str.ToCharArray().GroupBy(x=>x.ToString(),y=>y,(x,y)=>new { charData= x, Count=y.Count() }).ToArray();

            foreach (var item in output)
            {
                Console.WriteLine(item.charData + ":" + item.Count.ToString());
            }
        
        }



        public static dynamic Check(dynamic i)
        {
            return 0;
        }
    }
}
