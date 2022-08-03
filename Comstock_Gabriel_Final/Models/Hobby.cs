using System;
using System.ComponentModel.DataAnnotations;

namespace Comstock_Gabriel_Final.Models
{
    public class Hobby
    {
        public int HobbyId { get; set; }

        public string HobbyFullName { get; set; }

        public int CostOfHobby { get; set; }

        public string TypeOfHobby { get; set; }
        public int YearsDoingHobby {get; set; }
    }
}