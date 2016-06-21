using HiMVC.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiMVC.Models.Interfaces
{
    public interface IRepository
    {
        Task<Student> GetStudent(int studentId);

        Task<IEnumerable<Student>> GetAllStudentsAsync();

        void UpdateStudent(Student student);

        Task UpdateStudentAsync(Student student);

        void DeleteStudentAsync(int studentId);

        Task<IEnumerable<Lecturer>> GetAllLecturersAsync();
    }
}