using SMEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SMModels;
using SMDBContext;

namespace SMRepository
{
  public  class SubjectRepository
    {

        public KpmDbContext KpmDbContext { get; set; }
        public SubjectRepository(KpmDbContext kpmDbContext)
        {
            KpmDbContext = kpmDbContext;
        }
        
        public List<Subject> GetSubjectList()
        {
            List<Subject> Subjects = new List<Subject>();

            Subjects.Add(new Subject
            {
                Id = 1,
             Name="Angular"
            });

            Subjects.Add(new Subject
            {
                Id = 2,
               Name="MVC"
            });


            Subjects.Add(new Subject
            {
                Id = 3,
               Name="Java"
            });
            return Subjects;
        }

        public List<Subject> GetAllSubjectList()
        {

            return KpmDbContext.Subjects.ToList();
        }

        public List<Subject> GetSubject<T>(IEnumerable<T> ISubjects) where T : ISubject
        {
           List<int> ids= ISubjects.Select(x => x.SubjectId).Distinct().ToList();
            return KpmDbContext.Subjects.Where(x=>ids.Contains(x.Id)).ToList();
        }

        public void SetSubject<T>(IEnumerable<T> ISubjects, List<Subject> subjects) where T: ISubject
        {

            foreach (var item in ISubjects)
            {
                item.Subjects = subjects.FirstOrDefault(x => x.Id == item.SubjectId);
            }
        }

        public List<Subject> GetSubjectList(SubjectSearch SubjectSearch)
        {
            var Subjects = GetSubjectList();
            return GetOrderBy(Subjects, SubjectSearch.ColumnName, SubjectSearch.OrderBy);
        }

        List<Subject> GetOrderBy(List<Subject> Subjects, string columnName, string orderBy)
        {

            if("guid".Equals(columnName, StringComparison.OrdinalIgnoreCase))
            {
                if("desc".Equals(orderBy, StringComparison.OrdinalIgnoreCase))
                {
                    return Subjects.OrderByDescending(x => x.Id).ToList();
                } 
                
                return Subjects.OrderBy(x => x.Id).ToList();                 
            }

            if (columnName.Equals("name", StringComparison.OrdinalIgnoreCase))
            {
                if (orderBy.Equals("desc", StringComparison.OrdinalIgnoreCase))
                {
                    return Subjects.OrderByDescending(x => x.Name).ToList();
                }
                else
                {
                    return Subjects.OrderBy(x => x.Name).ToList();
                }
            }

           




            return Subjects;
        }


        public object GetSubjectList(string columnName, string orderBy)
        {

            var Subjects = GetSubjectList();
            return GetOrderBy(Subjects,columnName,orderBy);
        }
    }
}
