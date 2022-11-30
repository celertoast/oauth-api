using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMEntities;
using SMModels;
using SMMVC.Filters;
using SMServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMWebAPI.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        public StudentService StudentService { get; set; }
        public SubjectService SubjectService { get; set; }

        public StudentController(StudentService studentService, SubjectService subjectService)
        {
            StudentService = studentService;
            SubjectService = subjectService;
        }

        
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetAsync()
        {
            StudentSearch studentSearch = new StudentSearch();
            var students = StudentService.GetStudentList(studentSearch);

            studentSearch.Students = students;

            return Ok(studentSearch);
        }



        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> PostAsync(StudentSearch studentSearch)
        {
          
            var students = StudentService.GetStudentList(studentSearch);

            studentSearch.Students = students;

            return Ok(studentSearch);
        }


        [HttpPost]
        [Route("Save")]
        [HttpPost]
        public IActionResult Save(Student student)
        {
            if (ModelState.IsValid)
            {
                student = StudentService.Save(student);

            }
             

            return Ok(student);
        }


        [HttpGet]
        [Route("DeleteStudent/{id}")]

        public IActionResult DeleteStudent(int id)
        {
            var value = StudentService.Delete(id);
            if (value == 1)
            {
                return Ok("Deleted Successfully");
            }else
            {
                return NotFound();
            }

           
        }


        [HttpGet]
        [Route("GetStudent/{id}")]
        [QdnAuthFilter(Role = "sales")]
        public IActionResult GetStudent(int id)
        {
            var student = StudentService.GetStudentById(id);

            if(student is null)
            {
                return NotFound();
            }

            return Ok(student);
        }

    }
}
