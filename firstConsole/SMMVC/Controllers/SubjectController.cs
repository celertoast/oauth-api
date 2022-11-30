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

namespace SMMVC.Controllers
{

    //Name + Controller 
    //Subject + Controller 


    public class SubjectController : Controller
    {
        public SubjectService SubjectService { get; set; }

        public SubjectController(SubjectService subjectService)
        {
            SubjectService = subjectService;
        }

        // Microsoft.AspNetCore.Mvc.Razor.RazorPage

        public IActionResult Index()
        {

            return View();
        }


        public async Task<IActionResult> ListAsync(SubjectSearch SubjectSearch)
        {
            var Subjects = SubjectService.GetSubjectList(SubjectSearch);
            SubjectSearch.ReversOrderBy();
            ViewBag.orderBy = SubjectSearch.OrderBy;
            return View(Subjects);
        }

        //var text = "<h1>Hello, Async Response!</h1>";
        //byte[] data = System.Text.Encoding.UTF8.GetBytes(text);
        //await Response.Body.WriteAsync(data, 0, data.Length);
        //HttpContext.Response.StatusCode = StatusCodes.Status200OK;


        public IActionResult Save(Subject Subject, Teacher teacher)
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
            Subject Subject2 = new Subject();

            ModelBinder.Binder(Subject2, dct);

            Teacher teacher2 = new Teacher();

            ModelBinder.Binder(teacher2, dct);

            if (Subject.Id > 2)
            {
                return View("List", Subject);
            }
            else
            {
                return View("~/Views/Home/Index.cshtml", Subject);
            }
        }

    }
}
