using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission8_Group.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Mission8_Group.Models;

namespace Mission8_Group.Controllers
{
    public class HomeController : Controller
    {
        private TaskContext taskContext { get; set; }

        public HomeController(TaskContext tc)
        {
            taskContext = tc;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Quadrants()
        {
            var diList = taskContext.Responses.ToList();

            return View(diList);
        }

        [HttpGet]
        public IActionResult TaskForm()
        {
            ViewBag.Categories = taskContext.Categories.ToList();
            return View("TaskForm", new Form());
        }

        [HttpPost]
        public IActionResult TaskForm(Form f)
        {
            if (ModelState.IsValid)
            {
                taskContext.Add(f);
                taskContext.SaveChanges();
                return RedirectToAction("TaskForm");
            }
            else
            {
                ViewBag.Categories = taskContext.Categories.ToList();
                return View();
            }
        }

        //getter for the editing of fields
        [HttpGet]
        public IActionResult Edit(int taskId)
        {
            ViewBag.Categories = taskContext.Categories.ToList(); ;

            var application = taskContext.Responses.Single(x => x.taskId == taskId);

            return View("TaskForm", application);
        }

        //Post for the editing of fields
        [HttpPost]
        public IActionResult Edit(Form blah)
        {
            taskContext.Update(blah);
            taskContext.SaveChanges();

            return RedirectToAction("Quadrants");
        }

        //Getter for deleting
        [HttpGet]
        public IActionResult Delete(int taskId)
        {
            var application = taskContext.Responses.Single(x => x.taskId == taskId);

            return View(application);
        }

        //Post for deleting
        [HttpPost]
        public IActionResult Delete(Form f)
        {
            taskContext.Responses.Remove(f);
            taskContext.SaveChanges();

            return RedirectToAction("Quadrants");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
