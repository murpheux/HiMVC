using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using HiMVC.Models;
using AutoMapper;
using Microsoft.Data.Entity;
using HiMVC.Services;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using Microsoft.AspNet.Authorization;
using ServiceStack.Redis;
using HiMVC.Models.Interfaces;
using HiMVC.ViewModels;
using HiMVC.Models.Domain;
using System.Collections;
using Microsoft.AspNet.Mvc.Rendering;

namespace HiMVC.Controllers
{
    [AllowAnonymous]
    //[Route("Home")]
    public class HomeController : BaseController
    {
        [FromServices]
        public IEmailSender EmailSender { get; set; }

        public HomeController(IRepository repository, ILoggerFactory loggerFactory) : 
            base(repository, loggerFactory) { }

        public IActionResult Index()
        {
            var user = User.GetUserId();

            // send startup email
            EmailSender.SendEmailAsync("dapo.onawole@gmail.com", "Hi", "Just some test messages");

            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "About Studential";
            ViewData["Message"] = "Lorem Ipsum.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact Studential";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        // ------------------------------------------------------------

        [HttpGet("[action]")]
        [AllowAnonymous]
        public IActionResult Student()
        {
            var lecturers = _repository.GetAllLecturersAsync().Result;
            ViewBag.Lecturers = lecturers.Select(p => new SelectListItem { Value = p.LecturerId.ToString(), Text = p.Abbreviated });

            return View();
        }

        [HttpPost("[action]")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Student(StudentModel studentModel)
        {
            if (ModelState.IsValid)
            {
                var mapper = MappingConfig.mapperConfig.CreateMapper();
                var student = mapper.Map<StudentModel, Student>(studentModel);

                await _repository.UpdateStudentAsync(student);

                return RedirectToAction("StudentList");
            }
            else
            {
                ViewBag.Country = "CA";
                ViewBag.StutusMessage = "Invalid model state!";

                return View(studentModel);
            }
        }


        public async Task<IActionResult> StudentList()
        {
            var data = await _repository.GetAllStudentsAsync();

            var mapper = MappingConfig.mapperConfig.CreateMapper();
            var viewStudents = mapper.Map<IEnumerable<Student>, IEnumerable<StudentModel>>(data);

            return View(viewStudents);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateStudent(StudentModel studentModel)
        {
            var mapper = MappingConfig.mapperConfig.CreateMapper();
            var student = mapper.Map<StudentModel, Student>(studentModel);

            _repository.UpdateStudentAsync(student);

            return RedirectToAction("StudentList");
        }

        public ActionResult EditStudent(int Id)
        {
            var model = GetStudentModel(Id);

            return View(model);
        }

        private StudentModel GetStudentModel(int studentId)
        {
            var student = _repository.GetStudent(studentId).Result;

            var mapper = MappingConfig.mapperConfig.CreateMapper();
            return mapper.Map<Student, StudentModel>(student);
        }

        public ActionResult ViewStudent(int Id)
        {
            var model = GetStudentModel(Id);

            return View(model);
        }

        public ActionResult DeleteStudent(int Id)
        {
            _repository.DeleteStudentAsync(Id);
            
            return RedirectToAction("StudentList");
        }

        // GET: Movies/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            //var student = await _repository.Persons.SingleOrDefaultAsync(m => m.ID == id);
            //if (student == null)
            {
                return HttpNotFound();
            }
            //return View(student);
            return View();
        }

        public IActionResult ShowMap(string country = "Canada")
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,Name,Age,Sex")] Student student)
        {
            if (id != student.StudentId)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_repository.Update(movie);
                    //await _repository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(student.StudentId))
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(student);
        }

        private bool MovieExists(object iD)
        {
            return false;
        }


        // ------------------------------------------------------------
        // web api
        [Route("~/api/all")]
        public async Task<IActionResult> GetAllStudents()
        {
            var data = await _repository.GetAllStudentsAsync();

            var mapper = MappingConfig.mapperConfig.CreateMapper();
            var viewStudents = mapper.Map<IEnumerable<Student>, IEnumerable<StudentModel>>(data);

            return new ObjectResult(viewStudents);
        }

    }
}
