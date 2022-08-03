using System;
using System.ComponentModel.DataAnnotations;

namespace Comstock_Gabriel_Final.Models
{
    public class BreakfastFood
    {
        [Key]
        public int FoodId { get; set; }

        public string FoodFullName { get; set; }

        public string FoodName { get; set; }

        public double Cost { get; set; }
        public int TimeToPrepare {get; set; }
    }
}