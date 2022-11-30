using System;
using System.Collections.Generic;
using System.Text;

namespace SMModels
{
   public class Page
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int TotalRows { get; set; }

        public int RowCount { get; set; }

        public int CurrentRowStart { get; set; }

        public int CurrentRowEnd { get; set; }

    }
}
