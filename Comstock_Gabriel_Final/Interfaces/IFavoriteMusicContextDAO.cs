using System.Collections.Generic;
using Comstock_Gabriel_Final.Models;

namespace Comstock_Gabriel_Final.Interfaces
{
    public interface IFavoriteMusicContextDAO
    {
        List<Music> GetAllMusic();
        Music GetMusicById(int id);
        int? Add(Music music);
        int? RemoveMusicById(int id);
        int? UpdateMusic(Music music);
    }
}