using System;
using System.Collections.Generic;
using System.Text;

namespace SMModels
{
  public class SubjectSearch : BaseSearch
    {
          public string IdText { get; set; }

         public string NameText { get; set; }

         public override string ColumnName
        {
            get
            {

                if (string.IsNullOrWhiteSpace(_columnName))
                {
                    return "guid";
                }
                return _columnName;

            }

            set
            {

                if (string.IsNullOrWhiteSpace(value))
                {
                    _columnName = "guid";
                }
                else
                {
                    _columnName = value.ToLower();
                }
            }




        }

    }
}
