using System;
using System.Collections.Generic;

namespace SMUtilities
{
    public class ModelBinder
    {
        public static void Binder<T>(T model, Dictionary<string, string> dct)
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
                            item.SetValue(model, int.Parse(dct[key]));
                            break;

                        case "System.Single":
                            item.SetValue(model, float.Parse(dct[key]));
                            break;

                        case "System.Decimal":
                            item.SetValue(model, decimal.Parse(dct[key]));
                            break;
                        case "System.String":
                            item.SetValue(model, dct[key]);
                            break;


                    }


                }

            }
        }


    }
}
