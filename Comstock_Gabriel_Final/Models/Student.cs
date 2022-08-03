using System;
using System.ComponentModel.DataAnnotations;

namespace Comstock_Gabriel_Final.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string FullName { get; set; }

        public int Birthdate { get; set; }

        public string CollegeProgram { get; set; }
        public int YearInProgram {get; set; }
    }
}