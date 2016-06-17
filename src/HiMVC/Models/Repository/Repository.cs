using HiMVC.Data;
using HiMVC.Models.Domain;
using HiMVC.Models.Interfaces;
using Microsoft.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiMVC.Models.Repository
{
    public class Repository : IRepository
    {
        DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public async void DeleteStudentAsync(int studentId)
        {
            var student = await _context.Students.Where(s => s.StudentId == studentId).SingleOrDefaultAsync();

            _context.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            var data = _context.Students.Select(p => new Student()
            {
                StudentId = p.StudentId,
                Name = p.Name,
                Age = p.Age,
                Sex = p.Sex
            });

            return await data.ToArrayAsync();
        }

        public async Task<Student> GetStudent(int studentId)
        {
            var data = _context.Students.Where(p => p.StudentId == studentId)
                .Select(p => new Student()
                {
                    StudentId = p.StudentId,
                    Name = p.Name,
                    Age = p.Age,
                    Sex = p.Sex
                }).SingleOrDefaultAsync();

            return await data;
        }

        public async Task UpdateStudentAsync(Student student)
        {

            if (student.StudentId == 0)
                // persist student
                _context.Students.Add(student);
            else
            {
                var stud = _context.Students.Where(s => s.StudentId == student.StudentId).SingleOrDefault();

                // pass data
                stud.Name = student.Name;
                stud.Age = student.Age;
                stud.Sex = student.Sex;
                //stud.Email = student.Email;
            }    

            await _context.SaveChangesAsync();
        }
    }
}
