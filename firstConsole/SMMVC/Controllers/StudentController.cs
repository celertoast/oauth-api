using Microsoft.AspNetCore.Mvc;
using SMEntities;
using SMUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Http;
using SMServices;
using SMModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using SMMVC.Filters;

namespace SMMVC.Controllers
{

    //Name + Controller 
    //Student + Controller 



    [Authorize]
    public class StudentController : Controller
    {
        public StudentService StudentService { get; set; }
        public SubjectService SubjectService { get; set; }

        public StudentController(StudentService studentService, SubjectService subjectService)
        {
            StudentService = studentService;
            SubjectService = subjectService;
        }

        // Microsoft.AspNetCore.Mvc.Razor.RazorPage

        public IActionResult Index()
        {
            
            return View();
        }


        public async Task<IActionResult> ListAsync(StudentSearch studentSearch, string isAjax)
        {
            var students = StudentService.GetStudentList(studentSearch);
            //studentSearch.ReversOrderBy();
            ViewBag.studentSearch = studentSearch;
            ViewBag.orderBy = studentSearch.OrderBy;

            if (Request.Method.Equals("POST") && !string.IsNullOrWhiteSpace(isAjax) && isAjax.Equals("1"))
            {
                return PartialView("Table",students);
            }
            else
            {
                return View(students);
            }
            
        }


        public async Task<IActionResult> AddAsync()
        {
            // Student s = new Student();
            Student s = new Student();

            List<Subject> lstSubject = SubjectService.GetSubjectList();
            ViewBag.SubjectList = new SelectList(lstSubject, "Id", "Name");


            return View("Edit",s);
        }


        [QdnAuthFilter(Role ="admin,sales")]
        public async Task<IActionResult> EditAsync(int id)
        {

           // Student s = new Student();
            Student s=  StudentService.GetStudentById(id);

            List<Subject> lstSubject = SubjectService.GetSubjectList();
            ViewBag.SubjectList = new SelectList(lstSubject, "Id", "Name");


            return View(s);
        }

        //var text = "<h1>Hello, Async Response!</h1>";
        //byte[] data = System.Text.Encoding.UTF8.GetBytes(text);
        //await Response.Body.WriteAsync(data, 0, data.Length);
        //HttpContext.Response.StatusCode = StatusCodes.Status200OK;



        [HttpPost]
        public IActionResult Save(Student student)
        {
            if (ModelState.IsValid)
            {
                student = StudentService.Save(student);

            } else
            {
                List<Subject> lstSubject = SubjectService.GetSubjectList();
                ViewBag.SubjectList = new SelectList(lstSubject, "Id", "Name");
                return View("Edit", student);
            }

            return RedirectToAction("List");
        }


        public IActionResult Delete(int id)
        {

            StudentService.Delete(id);

            return RedirectToAction("List");

        }
            public IActionResult Save_old(Student student, Teacher teacher)
        {
            Dictionary<string, string> dct = new Dictionary<string, string>();

            //  Request.Query
            foreach (var item in Request.Form)
            {
                if (dct.ContainsKey(item.Key.ToLower()))
                {
                    dct[item.Key.ToLower()] = item.Value.FirstOrDefault();
                }
                else
                {
                    dct.Add(item.Key.ToLower(), item.Value.FirstOrDefault());
                }
            }
            foreach (var item in Request.Query)
            {
                if (dct.ContainsKey(item.Key.ToLower()))
                {
                    dct[item.Key.ToLower()] = item.Value.FirstOrDefault();
                }
                else
                {
                    dct.Add(item.Key.ToLower(), item.Value.FirstOrDefault());
                }
               
            }
            Student student2 = new Student();

            ModelBinder.Binder(student2, dct);

            Teacher teacher2 = new Teacher();

            ModelBinder.Binder(teacher2, dct);
 
            if (student.Id > 2)
            {
                return View("List", student);
            } else
            {
                return View("~/Views/Home/Index.cshtml", student);
            }
        }

    }
}
