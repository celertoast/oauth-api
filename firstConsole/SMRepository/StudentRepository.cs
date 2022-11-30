using SMEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SMModels;
using SMDBContext;
using Microsoft.EntityFrameworkCore;

namespace SMRepository
{
  public  class StudentRepository
    {

        private string QueryCount = "SELECT  Count(1) as Count  FROM [dbo].[TblStudent]  ts left Join  dbo.Tblsubject tsu on ts.SubjectId=tsu.id Where 1=1";

        private string Query = "SELECT  ts.id as id  ,ts.FirstName, ts.LastName, ts.StudentAge , ts.Doj, ts.Fees ,ts.SubjectId, tsu.Name  FROM [dbo].[TblStudent]  ts left Join  dbo.Tblsubject tsu on ts.SubjectId=tsu.id Where 1=1";
        public KpmDbContext KpmDbContext { get; set; }
        public StudentRepository(KpmDbContext kpmDbContext)
        {
            KpmDbContext = kpmDbContext;
        }
        public List<Student> GetStudentList()
        {
            List<Student> students = new List<Student>();


            for (int i = 1; i <= 1000; i++)
            {
                if (i % 3 == 0)
                {
                    students.Add(new Student
                    {
                        Id = i,
                        FirstName = "Kavita" +i.ToString(),
                        LastName = "P",
                        Age = 24+(i%20),
                        Doj = "12-03-2021",
                        Fees = 24000+i,
                        Subject = "Angular"
                    });
                }
                if (i % 3 == 1)
                {
                    students.Add(new Student
                    {
                        Id = i,
                        FirstName = "Abhay" + i.ToString(),
                        LastName = "V",
                        Age = 24 + (i % 20),
                        Doj = "12-03-2021",
                        Fees = 24000 + i,
                        Subject = "Angular"
                    });
                }
                if (i % 3 == 2)
                {
                    students.Add(new Student
                    {
                        Id = i,
                        FirstName = "Paritosh" + i.ToString(),
                        LastName = "VM",
                        Age = 24 + (i % 20),
                        Doj = "12-03-2021",
                        Fees = 24000 + i,
                        Subject = "Angular"
                    });
                }
            }         

            
            return students;
        }

        public Student Save(Student student)
        {
            if(student.Id == 0)
            {
                this.KpmDbContext.Students.Add(student);
            }else
            {
                KpmDbContext.Students.Attach(student);
                KpmDbContext.Entry(student).State = EntityState.Modified;
            }
            KpmDbContext.SaveChanges();

            return student;
        }


        public int Delete(int id)
        {

            var s = KpmDbContext.Students.FirstOrDefault(x => x.Id ==id);

            if (s is null)
            {
                return -1;
            }

            //KpmDbContext.Students.Attach(student);
            //KpmDbContext.Entry(student).State = EntityState.Deleted;


            KpmDbContext.Students.Remove(s);
            KpmDbContext.SaveChanges();

            return 1;
        }

        public int Delete(Student student)
        {
            if (student == null) return -1;
            return Delete(student.Id);
        }

        public Student GetStudentById(int id)
        {

          //  Single -> if we have two or more records it will throw error.
            Student s = KpmDbContext.Students.FirstOrDefault(x => x.Id == id);
            return s;
        }

        public List<Student> GetStudentList(StudentSearch studentSearch)
        {

            var Count = KpmDbContext.Students.Include(X => X.Subjects).GetWhere(studentSearch).Count();
            studentSearch.Page.TotalRows = Count;
            return KpmDbContext.Students
                .Include(X => X.Subjects)
                .GetWhere(studentSearch)
                .GetOrderBy(studentSearch)
                .GetPages(studentSearch)
                .AsNoTracking()
                .ToList();
        }
        

        public List<Student> GetStudentListQuery(StudentSearch studentSearch)
        {
            SqlParametersResult spr = new SqlParametersResult();
            KpmDbContext.Students.GetWhereQuery(studentSearch, spr);

            var Count = KpmDbContext.CountByRwSql(spr.GetWhereQuery(QueryCount), spr.SqlParameter.ToArray());

            studentSearch.Page.TotalRows = Count;
            spr = new SqlParametersResult();
            var data = KpmDbContext.Students.GetWhereQuery(studentSearch, spr).GetOrderByQuery(studentSearch, spr).FromSqlRaw(spr.GetQueryWithOrderBY(Query, studentSearch), spr.SqlParameter.ToArray()).ToList();
            return data;
            //var Count = KpmDbContext.Students.Include(X => X.Subjects).GetWhere(studentSearch).Count();
            //  studentSearch.Page.TotalRows = Count;
            //  return KpmDbContext.Students.Include(X=>X.Subjects).GetWhere(studentSearch).GetOrderBy(studentSearch).GetPages(studentSearch).ToList();
        }


        public object GetStudentList(string columnName, string orderBy)
        {

            var students = GetStudentList();
            return students;// GetOrderBy(students,columnName,orderBy);
        }
    }
}
