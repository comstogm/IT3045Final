using Comstock_Gabriel_Final.Models;
using Comstock_Gabriel_Final.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Comstock_Gabriel_Final.Data
{
    public class HobbyContextDAO : IHobbyContextDAO
    {
        private DatabaseContext _context;
        public HobbyContextDAO(DatabaseContext context)
        {
            _context = context;
        }

        public int? Add(Hobby hobby)
        {
            var hobbies = _context.Hobbies.Where(x => x.TypeOfHobby.Equals(hobby.TypeOfHobby)).FirstOrDefault();

            if(hobbies != null)
                return null;

            try
            {
                _context.Hobbies.Add(hobby);
                _context.SaveChanges();
                return 1;
            }
            catch(Exception)
            {
                return 0;
            }
        }

        public List<Hobby> GetAllHobbies()
        {
            return _context.Hobbies.ToList();
        }

        public Hobby GetHobbyById(int id)
        {
            return _context.Hobbies.Where(x=> x.HobbyId.Equals(id)).FirstOrDefault();
        }

        public int? RemoveHobbyById(int id)
        {
            var hobby = this.GetHobbyById(id);
            if(hobby == null)
                return null;
            try
            {
                _context.Hobbies.Remove(hobby);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
            
        }

        public int? UpdateHobby(Hobby hobby)
        {
            var hobbyUpdate = this.GetHobbyById(hobby.HobbyId);
            if(hobbyUpdate == null)
                return null;

            hobbyUpdate.HobbyFullName = hobby.HobbyFullName;
            hobbyUpdate.TypeOfHobby = hobby.TypeOfHobby;
            hobbyUpdate.CostOfHobby = hobby.CostOfHobby;
            hobbyUpdate.YearsDoingHobby = hobby.YearsDoingHobby;

            try
            {
                _context.Hobbies.Update(hobbyUpdate);
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