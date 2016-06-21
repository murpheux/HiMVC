using HiMVC.Data;
using HiMVC.Models.Domain;
using HiMVC.Models.Interfaces;
using Microsoft.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

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

        public async Task<IEnumerable<Lecturer>> GetAllLecturersAsync()
        {
            var data = _context.Lecturers.Select(p => new Lecturer()
            {
                LecturerId = p.LecturerId,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Title = p.Title,
                Rating = p.Rating,
            });

            return await data.ToArrayAsync();
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            var data = _context.Students.Select(p => new Student()
            {
                StudentId = p.StudentId,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                DateOfBirth = p.DateOfBirth,
                Sex = p.Sex,
                GPA = p.GPA,
                Nationality = p.Nationality,
            });

            return await data.ToArrayAsync();
        }

        public async Task<Student> GetStudent(int studentId)
        {
            var data = _context.Students.Where(p => p.StudentId == studentId)
                .Select(p => new Student()
                {
                    StudentId = p.StudentId,
                    FirstName = p.FirstName,
                    DateOfBirth = p.DateOfBirth,
                    Sex = p.Sex
                }).SingleOrDefaultAsync();

            return await data;
        }

        public void UpdateStudent(Student student)
        {

            if (student.StudentId == 0)
                // persist student
                _context.Students.Add(student);
            else
            {
                var stud = _context.Students.Where(s => s.StudentId == student.StudentId).SingleOrDefault();

                // pass data
                stud.FirstName = student.FirstName;
                stud.LastName = stud.LastName;
                stud.DateOfBirth = student.DateOfBirth;
                stud.Sex = student.Sex;
                stud.Email = student.Email;
                stud.GPA = student.GPA;
                stud.Nationality = student.Nationality;
            }

            _context.SaveChanges();
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
                stud.FirstName = student.FirstName;
                stud.DateOfBirth = student.DateOfBirth;
                stud.Sex = student.Sex;
                //stud.Email = student.Email;
            }    

            await _context.SaveChangesAsync();
        }
    }
}
