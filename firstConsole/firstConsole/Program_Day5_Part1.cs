using System;
using System.Collections.Generic;
using System.Text;

namespace firstConsole
{

    public static class PersonExt
    {
        public static void Print(this Person person)
        {
            Console.WriteLine("I am in Person Ext");
            Console.WriteLine(person.Name);
        }
    }
public    class Program_Day5_Part1
    {

        public static void Main_Day5_Part1(string[] arg)
        {

            Person person = new Person
            {
                Name = "Kavita"
            };

            person.Print();
        //    PersonExt.Print(person);
            Console.WriteLine("Hi");

            Console.ReadLine();
        }
    }
}
