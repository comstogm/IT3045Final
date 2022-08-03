using System.Collections.Generic;
using Comstock_Gabriel_Final.Models;

namespace Comstock_Gabriel_Final.Interfaces
{
    public interface IStudentContextDAO
    {
        List<Student> GetAllStudents();
        Student GetStudentById(int id);
        int? Add(Student student);
        int? RemoveStudentById(int id);
        int? UpdateStudent(Student student);
    }
}