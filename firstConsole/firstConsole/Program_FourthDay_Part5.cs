using System;
using System.Collections.Generic;
using System.Text;

namespace firstConsole
{
 public   class Program_FourthDay_Part5
    {

        public static void Main_Part5(string[] args)
        {

            Employee emp = new Employee();


            Person per = new Person();
            Dictionary<string, string> dct = new Dictionary<string, string>();
            dct.Add("id", "1");
            dct.Add("age", "25.2");

            dct.Add("agevalue", "26.2");
            dct.Add("name", "Kavita");
            dct.Add("lastname", "F");
            dct.Add("address", "magarpatta");
            //   ModelBinder(emp, dct);

            var lines = System.IO.File.ReadAllLines(@"D:\abhay\kavita\kavitamvcclass\firstConsole\firstConsole\TextFile1.txt");

            List<Employee> lstEmp = new List<Employee>();
            for (int i = 1; i < lines.Length; i++)
            {
                Employee e = new Employee();
             var arr=   lines[i].Split("|");
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("id", arr[0]);
                dict.Add("name", arr[1]);
                dict.Add("lastname", arr[2]);
                ModelBinder(e, dict);
                lstEmp.Add(e);

            }
                
                ModelBinder(per, dct);
            Console.ReadLine(); ;
        }


     public static void ModelBinder<T>(T model, Dictionary<string,string> dct)
        {
            var type = model.GetType();
            var properties = type.GetProperties();
            foreach (var item in properties)
            {
                var key = item.Name.ToLower();
                if (dct.ContainsKey(key))
                {

                    switch (item.PropertyType.FullName)
                    {
                        case "System.Int32":
                            item.SetValue(model, int.Parse( dct[key]));
                            break;

                        case "System.Single":
                            item.SetValue(model, float.Parse(dct[key]));
                            break;

                        case "System.Decimal":
                            item.SetValue(model, decimal.Parse(dct[key]));
                            break;
                        case "System.String":
                            item.SetValue(model,  dct[key]);
                            break;

                         
                    }

                    
                }

            }
        }


    }
}
