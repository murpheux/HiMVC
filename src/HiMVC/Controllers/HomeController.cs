using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using HiMVC.Models;
using AutoMapper;
using HiMVC.ViewModels.Domain;

namespace HiMVC.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        // ------------------------------------------------------------

        public IActionResult Student()
        {

            return View();
        }

        public IActionResult StudentList()
        {
            var data = _repository.GetAllStudents();

            var mapper = MappingConfig.mapperConfig.CreateMapper();
            var viewStudents = mapper.Map<List<Student>, List<StudentModel>>(data);

            return View(viewStudents);
        }


        [HttpPost]
        public ActionResult Student(StudentModel studentModel)
        {
            var mapper = MappingConfig.mapperConfig.CreateMapper();
            var student = mapper.Map<StudentModel, Student>(studentModel);

            _repository.NewStudent(student);

            return RedirectToAction("StudentList");
            //return "Data Saved Successfully!";
        }
    }
}
