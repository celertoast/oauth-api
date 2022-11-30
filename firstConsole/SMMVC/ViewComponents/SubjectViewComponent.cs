using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using SMEntities;
using SMServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMMVC.ViewComponents
{

    //Name + Controller +  
    //ViewName + Controller
    public class SubjectViewComponent : ViewComponent
    {
        SubjectService SubjectService { get; set; }
     public   SubjectViewComponent(SubjectService subjectService)
        {
            SubjectService = subjectService;
        }
        public ViewViewComponentResult Invoke(ISubject Subject)
        {
            List<Subject> lstSubject = SubjectService.GetSubjectList();
            ViewBag.SubjectList = new SelectList(lstSubject, "Id", "Name");

            
            return View(Subject);
        }
    }
}
