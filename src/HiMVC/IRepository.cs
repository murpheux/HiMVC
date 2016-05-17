using BellagioService.Service.v1.Models;
using HiMVC.Models;
using System;
using System.Collections.Generic;

namespace HiMVC
{
    public interface IRepository
    {

        List<Student> GetAllStudents();

        void NewStudent(Student student);

    }
}