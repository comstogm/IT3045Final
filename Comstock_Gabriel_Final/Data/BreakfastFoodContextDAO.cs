using Comstock_Gabriel_Final.Models;
using Comstock_Gabriel_Final.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Comstock_Gabriel_Final.Data
{
    public class BreakfastFoodContextDAO : IBreakfastFoodContextDAO
    {
        private DatabaseContext _context;
        public BreakfastFoodContextDAO(DatabaseContext context)
        {
            _context = context;
        }

        public int? Add(BreakfastFood food)
        {
            var foods = _context.BreakfastFoods.Where(x => x.FoodFullName.Equals(food.FoodName)).FirstOrDefault();

            if(foods != null)
                return null;

            try
            {
                _context.BreakfastFoods.Add(food);
                _context.SaveChanges();
                return 1;
            }
            catch(Exception)
            {
                return 0;
            }
            
        }

        public List<BreakfastFood> GetAllFoods()
        {
            return _context.BreakfastFoods.ToList();
        }

        public BreakfastFood GetFoodById(int id)
        {
            return _context.BreakfastFoods.Where(x=> x.FoodId.Equals(id)).FirstOrDefault();
        }

        public int? RemoveFoodById(int id)
        {
            var food = this.GetFoodById(id);
            if(food == null)
                return null;
            try
            {
                _context.BreakfastFoods.Remove(food);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
            
        }

        public int? UpdateFood(BreakfastFood food)
        {
            var foodToUpdate = this.GetFoodById(food.FoodId);
            if(foodToUpdate == null)
                return null;

            foodToUpdate.FoodFullName = food.FoodFullName;
            //foodToUpdate.FoodId = food.FoodId;
            foodToUpdate.Cost = food.Cost;
            foodToUpdate.FoodName = food.FoodName;
            foodToUpdate.TimeToPrepare = food.TimeToPrepare;

            try
            {
                _context.BreakfastFoods.Update(foodToUpdate);
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
