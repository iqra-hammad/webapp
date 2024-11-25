using Microsoft.AspNetCore.Mvc;
using webapp.Models;
using System.Collections.Generic;

namespace webapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly SurveyWebAppContext _surveyContext;

        public HomeController(SurveyWebAppContext surveyContext)
        {
            _surveyContext = surveyContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            
            ViewBag.Roles =_surveyContext.Roles.Select(r=> new {r.RoleId,r.URole}).ToList();
            ViewBag.Suggestions =_surveyContext.Suggestions.Select(s=> new {s.SuggestionId,s.Suggestions}).ToList();
            return View();  
        }

        [HttpPost]
        public IActionResult Index(Userdata ud)
        {
            if (ModelState.IsValid)
            {
                _surveyContext.Userdata.Add(ud);
                _surveyContext.SaveChanges();

                return RedirectToAction("Index");
            }


            ViewBag.Roles = _surveyContext.Roles.Select(r => new { r.RoleId, r.URole }).ToList();
            ViewBag.Suggestions = _surveyContext.Suggestions.Select(s => new { s.SuggestionId, s.Suggestions }).ToList();

            return View(ud);
        }
        
        
        
    }

}