using HiMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiMVC
{
    public class Repository : IRepository
    {
        public List<Student> GetAllStudents()
        {
            var db = new ApplicationDbContext();
            var data = db.Students.Select(p => new Student()
            {
                StudentId = p.StudentId,
                Name = p.Name,
                Age = p.Age,
                Sex = p.Sex
            }).ToList();

            return data;
        }

        public Student GetStudent(int studentId)
        {
            var db = new ApplicationDbContext();
            var data = db.Students.Where(p => p.StudentId == studentId)
                .Select(p => new Student()
                {
                    StudentId = p.StudentId,
                    Name = p.Name,
                    Age = p.Age,
                    Sex = p.Sex
                }).SingleOrDefault();

            return data;
        }

        public void NewStudent(Student student)
        {
            using (var db = new ApplicationDbContext())
            {
                // persist student
                db.Students.Add(student);
                db.SaveChanges();
            }
        }
    }
}
