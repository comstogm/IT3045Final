using Comstock_Gabriel_Final.Models;
using Comstock_Gabriel_Final.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Comstock_Gabriel_Final.Data
{
    public class StudentContextDAO : IStudentContextDAO
    {
        private DatabaseContext _context;
        public StudentContextDAO(DatabaseContext context)
        {
            _context = context;
        }

        public int? Add(Student student)
        {
            var students = _context.Students.Where(x => x.FullName.Equals(student.FullName)).FirstOrDefault();

            if(students != null)
                return null;

            try
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return 1;
            }
            catch(Exception)
            {
                return 0;
            }
        }

        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            return _context.Students.Where(x=> x.StudentId.Equals(id)).FirstOrDefault();
        }

        public int? RemoveStudentById(int id)
        {
            var student = this.GetStudentById(id);
            if(student == null)
                return null;
            try
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
            
        }

        public int? UpdateStudent(Student student)
        {
            var studentUpdate = this.GetStudentById(student.StudentId);
            if(studentUpdate == null)
                return null;

            studentUpdate.FullName = student.FullName;
            studentUpdate.Birthdate = student.Birthdate;
            studentUpdate.CollegeProgram = student.CollegeProgram;
            studentUpdate.YearInProgram = student.YearInProgram;

            try
            {
                _context.Students.Update(studentUpdate);
                _context.SaveChanges();
                return 1;
            }
            catch(Exception)
            {
                return 0;
            }
            
        }
    }
}