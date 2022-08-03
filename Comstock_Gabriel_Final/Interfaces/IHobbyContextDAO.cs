using System.Collections.Generic;
using Comstock_Gabriel_Final.Models;

namespace Comstock_Gabriel_Final.Interfaces
{
    public interface IHobbyContextDAO
    {
        List<Hobby> GetAllHobbies();
        Hobby GetHobbyById(int id);
        int? Add(Hobby hobby);
        int? RemoveHobbyById(int id);
        int? UpdateHobby(Hobby hobby);
    }
}