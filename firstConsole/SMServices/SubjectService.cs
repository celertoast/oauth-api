using SMEntities;
using SMModels;
using SMRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMServices
{
   public class SubjectService
    {

        SubjectRepository SubjectRepository;

        public SubjectService(SubjectRepository subjectRepository)
        {
            SubjectRepository = subjectRepository;
        }

        public List<Subject> GetSubjectList()
        {           
            return SubjectRepository.GetSubjectList();
        }

        public object GetSubjectList(string columnName ="id", string orderBy="desc")
        {
            if (string.IsNullOrWhiteSpace(columnName))
            {
                columnName = "id";
            }

            if (string.IsNullOrWhiteSpace(orderBy))
            {
                orderBy = "desc";
            }


            return SubjectRepository.GetSubjectList(columnName, orderBy);
        }

        public object GetSubjectList(SubjectSearch SubjectSearch)
        {          
            return SubjectRepository.GetSubjectList(SubjectSearch);
        }
    }
}
