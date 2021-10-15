using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewController.Models;
using ViewController.Services;
using System.IO;

namespace ViewController.Controllers
{
    [Route("[Controller]/")]
    public class StudentController : Controller
    {
        public StudentService StudentService;

        public StudentController(StudentService service)
        {
            StudentService = service;
        }

        public ActionResult Index()
        {
            return View(StudentService.Students);
        }

        [Route("create/{name}/{surname}/{techno}")]
        public ActionResult Create(string name, string surname, string techno)
        {
            StudentModel student = new StudentModel()
            {
                Name = name,
                Surname = surname,
                Techno = techno
            };
            StudentService.AddStudent(student);
            return RedirectToAction("Index");
        }

        [Route("delete/{name}/{surname}")]
        public ActionResult Delete(string name, string surname)
        {
            StudentService.DeleteStudent(name, surname);
            return RedirectToAction("Index");
        }

        [Route("update/{name}/{surname}/{techno}")]
        public ActionResult Update(string name, string surname, string techno)
        {
            StudentService.UpdateStudent(name, surname, techno);
            return RedirectToAction("Index");
        }
    }
}
