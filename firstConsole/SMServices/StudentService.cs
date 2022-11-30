using SMEntities;
using SMModels;
using SMRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMServices
{
   public class StudentService
    {

        StudentRepository StudentRepository;
        SubjectRepository SubjectRepository;
        public StudentService(StudentRepository studentRepository, SubjectRepository subjectRepository)
        {
            StudentRepository = studentRepository;
            SubjectRepository = subjectRepository;
        }

        public List<Student> GetStudentList()
        {           
            return StudentRepository.GetStudentList();
        }

        public object GetStudentList(string columnName ="id", string orderBy="desc")
        {
            if (string.IsNullOrWhiteSpace(columnName))
            {
                columnName = "id";
            }

            if (string.IsNullOrWhiteSpace(orderBy))
            {
                orderBy = "desc";
            }


            return StudentRepository.GetStudentList(columnName, orderBy);
        }

        public List<Student> GetStudentList(StudentSearch studentSearch)
        {
            List<Student> lstStudent = StudentRepository.GetStudentList(studentSearch);

           /// List<Subject> subjects = SubjectRepository.GetAllSubjectList();
            List<Subject> subjects = SubjectRepository.GetSubject(lstStudent);
            SubjectRepository.SetSubject(lstStudent, subjects);
            return lstStudent;
        }

        public Student GetStudentById(int id)
        {

            Student s = StudentRepository.GetStudentById(id);

            return s;
        }

        public Student Save(Student student)
        {
          student=  StudentRepository.Save(student);

            return student;
        }

        public int Delete(int id)
        {
            return StudentRepository.Delete(id);
        }
    }
}
