using System.Collections.Generic;
using Comstock_Gabriel_Final.Models;

namespace Comstock_Gabriel_Final.Interfaces
{
    public interface IBreakfastFoodContextDAO
    {
        List<BreakfastFood> GetAllFoods();
        BreakfastFood GetFoodById(int id);
        int? Add(BreakfastFood food);
        int? RemoveFoodById(int id);
        int? UpdateFood(BreakfastFood food);
    }
}