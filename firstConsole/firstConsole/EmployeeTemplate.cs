using System;
using System.Collections.Generic;
using System.Text;

namespace firstConsole
{
    public class EmployeeTemplate
    {
        dynamic Model;

      public  StringBuilder sb = new StringBuilder();

        public EmployeeTemplate(dynamic model)
        {
            Model = model;
        }

        public void Execute()
        {
            sb.Append(@"<!DOCTYPE html>");

            sb.Append("<html lang=\"en\" xmlns=\"http://www.w3.org/1999/xhtml\">");
            sb.Append("<head>");
            sb.Append("<meta charset=\"utf - 8\" />");
            sb.Append("<title></title>");
            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append("<div>");
            sb.Append("<label>Id</label>:<span>");
            sb.Append(Model.Id);
            sb.Append("</span>");
            sb.Append("\r\n</div>");

            sb.Append("<div>");
            sb.Append("<label>Name</label>:<span>");
            sb.Append(Model.Name);
            sb.Append("</span>");
            sb.Append("\r\n</div>");

            sb.Append("<div>");
            sb.Append("<label>Last Name</label>:<span>");
            sb.Append(Model.LastName);
            sb.Append("</span>");
            sb.Append("\r\n</div>");

            sb.Append("</body>");
            sb.Append("</html>");

        }

    }
}
