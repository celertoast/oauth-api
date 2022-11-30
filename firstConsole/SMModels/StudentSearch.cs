using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SMEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SMModels
{
    public class StudentSearch : BaseSearch
    {

        [Display(Name = "Id")]
        public string IdText { get; set; }


        [Display(Name = "First Name")]
        public string FirstNameText { get; set; }

        [Display(Name = "Last Name")]
        public string LastNameText { get; set; }


        [Display(Name = "Age")]
        public string AgeText { get; set; }


        [Display(Name = "Age From")]
        public string AgeGteText { get; set; }

        [Display(Name = "Age To")]
        public string AgeLteText { get; set; }


        [Display(Name = "Subject")]
        public string SubjectText { get; set; }

        [Display(Name = "Doj")]
        public string DojText { get; set; }

        [Display(Name = "Fees")]
        public string FeesText { get; set; }


        public virtual string OrderBy
        {
            get
            {

                if (string.IsNullOrWhiteSpace(_orderBy))
                {
                    return "asc";
                }
                return _orderBy;

            }
            set
            {

                if (string.IsNullOrWhiteSpace(value))
                {
                    _orderBy = "asc";
                }
                else
                {
                    _orderBy = value.ToLower();
                }
            }
        }


        public List<Student> Students { get; set; }

        public IEnumerable<Student> GetWere(IEnumerable<Student> students)
        {
            //1000
            StudentSearch studentSearch = this;
            if (!string.IsNullOrWhiteSpace(studentSearch.FirstNameText))
            {
                students = students.Where(x => x.FirstName.Contains(studentSearch.FirstNameText, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            //50
            if (!string.IsNullOrWhiteSpace(studentSearch.LastNameText))
            {
                students = students.Where(x => x.LastName.Contains(studentSearch.LastNameText, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            //50
            if (!string.IsNullOrWhiteSpace(studentSearch.IdText))
            {
                int id = 0;
                var isValid = int.TryParse(studentSearch.IdText, out id);
                if (isValid)
                {
                    students = students.Where(x => x.Id == id).ToList();
                }
            }

            //50
            if (!string.IsNullOrWhiteSpace(studentSearch.AgeGteText))
            {
                int ageGte = 0;
                var isValid = int.TryParse(studentSearch.AgeGteText, out ageGte);
                if (isValid)
                {
                    students = students.Where(x => x.Age >= ageGte).ToList();
                }
            }

            //50
            if (!string.IsNullOrWhiteSpace(studentSearch.AgeLteText))
            {
                int ageLte = 0;
                var isValid = int.TryParse(studentSearch.AgeLteText, out ageLte);
                if (isValid)
                {
                    students = students.Where(x => x.Age <= ageLte).ToList();
                }
            }


            return students;
        }


        public IEnumerable<Student> GetOrderBy(IEnumerable<Student> students)
        {

            if ("id".Equals(this.ColumnName, StringComparison.OrdinalIgnoreCase))
            {
                if ("desc".Equals(this.OrderBy, StringComparison.OrdinalIgnoreCase))
                {
                    return students.OrderByDescending(x => x.Id).ToList();
                }

                return students.OrderBy(x => x.Id).ToList();
            }

            if (this.ColumnName.Equals("firstname", StringComparison.OrdinalIgnoreCase))
            {
                if (this.OrderBy.Equals("desc", StringComparison.OrdinalIgnoreCase))
                {
                    return students.OrderByDescending(x => x.FirstName).ToList();
                }
                else
                {
                    return students.OrderBy(x => x.FirstName).ToList();
                }
            }

            if (this.ColumnName.Equals("lastname", StringComparison.OrdinalIgnoreCase))
            {
                if (this.OrderBy.Equals("desc", StringComparison.OrdinalIgnoreCase))
                {
                    return students.OrderByDescending(x => x.LastName).ToList();
                }
                return students.OrderBy(x => x.LastName).ToList();

            }





            return students;
        }

    }






    public static class StudentLogics{


        public static DbSet<Student> GetWhereQuery(this DbSet<Student> students, StudentSearch studentSearch, SqlParametersResult spr)
        { StringBuilder sb = new StringBuilder(string.Empty);
            
            if (!string.IsNullOrWhiteSpace(studentSearch.FirstNameText))
            {
                sb.Append($" and FirstName like @FirstName");
                SqlParameter sp = new SqlParameter();
                sp.ParameterName = "@FirstName";
                sp.Value ="%"+ studentSearch.FirstNameText +"%";
                spr.SqlParameter.Add(sp);
            }

            spr.WhereQuery = sb.ToString();
            return students;
        }



        public static DbSet<Student> GetOrderByQuery(this DbSet<Student> students, StudentSearch studentSearch,SqlParametersResult spr)
        {
            if ("id".Equals(studentSearch.ColumnName, StringComparison.OrdinalIgnoreCase))
            {
                if ("desc".Equals(studentSearch.OrderBy, StringComparison.OrdinalIgnoreCase))
                {
                    spr.OrderByQuery = spr.OrderByQuery + " id desc ";
                } else
                {
                    spr.OrderByQuery = spr.OrderByQuery + " id asc ";
                }

                
            }

            if (studentSearch.ColumnName.Equals("firstname", StringComparison.OrdinalIgnoreCase))
            {
                if (studentSearch.OrderBy.Equals("desc", StringComparison.OrdinalIgnoreCase))
                {
                    spr.OrderByQuery = spr.OrderByQuery + " firstName desc ";
                }
                else
                {
                    spr.OrderByQuery = spr.OrderByQuery + " FirstName asc ";
                }
            }


            if (studentSearch.ColumnName.Equals("lastname", StringComparison.OrdinalIgnoreCase))
            {
                if (studentSearch.OrderBy.Equals("desc", StringComparison.OrdinalIgnoreCase))
                {
                    spr.OrderByQuery = spr.OrderByQuery + " lastName desc ";
                } else
                {
                    spr.OrderByQuery = spr.OrderByQuery + " lastName asc ";
                }
                

            }

            return students;
            //if (studentSearch.ColumnName.Equals("firstname", StringComparison.OrdinalIgnoreCase))
            //{
            //    if (studentSearch.OrderBy.Equals("desc", StringComparison.OrdinalIgnoreCase))
            //    {
            //        return students.OrderByDescending(x => x.FirstName);
            //    }
            //    else
            //    {
            //        return students.OrderBy(x => x.FirstName);
            //    }
            //}

            //if (studentSearch.ColumnName.Equals("lastname", StringComparison.OrdinalIgnoreCase))
            //{
            //    if (studentSearch.OrderBy.Equals("desc", StringComparison.OrdinalIgnoreCase))
            //    {
            //        return students.OrderByDescending(x => x.LastName);
            //    }
            //    return students.OrderBy(x => x.LastName);

            //}


            //if (studentSearch.ColumnName.Equals("Subjects.Name", StringComparison.OrdinalIgnoreCase))
            //{
            //    if (studentSearch.OrderBy.Equals("desc", StringComparison.OrdinalIgnoreCase))
            //    {
            //        return students.OrderByDescending(x => x.Subjects.Name);
            //    }
            //    return students.OrderBy(x => x.Subjects.Name);

            //}
            //return students;
        }



        public static IQueryable<Student> GetWhere(this IQueryable<Student> students, StudentSearch studentSearch)
        {    //1000            
            if (!string.IsNullOrWhiteSpace(studentSearch.FirstNameText))
            {
                students = students.Where(x => x.FirstName.IndexOf(studentSearch.FirstNameText) > -1);
            }

            //50
            if (!string.IsNullOrWhiteSpace(studentSearch.LastNameText))
            {
                students = students.Where(x => EF.Functions.Like(x.LastName,"%"+studentSearch.LastNameText+"%"));
            }

            //50
            if (!string.IsNullOrWhiteSpace(studentSearch.IdText))
            {
                int id = 0;
                var isValid = int.TryParse(studentSearch.IdText, out id);
                if (isValid)
                {
                    students = students.Where(x => x.Id == id);
                }
            }

            //50
            if (!string.IsNullOrWhiteSpace(studentSearch.AgeGteText))
            {
                int ageGte = 0;
                var isValid = int.TryParse(studentSearch.AgeGteText, out ageGte);
                if (isValid)
                {
                    students = students.Where(x => x.Age >= ageGte);
                }
            }

            //50
            if (!string.IsNullOrWhiteSpace(studentSearch.AgeLteText))
            {
                int ageLte = 0;
                var isValid = int.TryParse(studentSearch.AgeLteText, out ageLte);
                if (isValid)
                {
                    students = students.Where(x => x.Age <= ageLte);
                }
            }

            return students;
        }


        public static IQueryable<Student> GetOrderBy(this IQueryable<Student> students, StudentSearch studentSearch)
        {
            if ("id".Equals(studentSearch.ColumnName, StringComparison.OrdinalIgnoreCase))
            {
                if ("desc".Equals(studentSearch.OrderBy, StringComparison.OrdinalIgnoreCase))
                {
                    return students.OrderByDescending(x => x.Id);
                }

                return students.OrderBy(x => x.Id);
            }

            if (studentSearch.ColumnName.Equals("firstname", StringComparison.OrdinalIgnoreCase))
            {
                if (studentSearch.OrderBy.Equals("desc", StringComparison.OrdinalIgnoreCase))
                {
                    return students.OrderByDescending(x => x.FirstName);
                }
                else
                {
                    return students.OrderBy(x => x.FirstName);
                }
            }

            if (studentSearch.ColumnName.Equals("lastname", StringComparison.OrdinalIgnoreCase))
            {
                if (studentSearch.OrderBy.Equals("desc", StringComparison.OrdinalIgnoreCase))
                {
                    return students.OrderByDescending(x => x.LastName);
                }
                return students.OrderBy(x => x.LastName);

            }


            if (studentSearch.ColumnName.Equals("Subjects.Name", StringComparison.OrdinalIgnoreCase))
            {
                if (studentSearch.OrderBy.Equals("desc", StringComparison.OrdinalIgnoreCase))
                {
                    return students.OrderByDescending(x => x.Subjects.Name);
                }
                return students.OrderBy(x => x.Subjects.Name);

            }
            return students;
        }




    }


}
