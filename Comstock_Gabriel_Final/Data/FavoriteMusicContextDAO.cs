using Comstock_Gabriel_Final.Models;
using Comstock_Gabriel_Final.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Comstock_Gabriel_Final.Data
{
    public class FavoriteMusicContextDAO : IFavoriteMusicContextDAO
    {
        private DatabaseContext _context;
        public FavoriteMusicContextDAO(DatabaseContext context)
        {
            _context = context;
        }
        public int? Add(Music music)
        {
            var musics = _context.FavoriteMusic.Where(x => x.MusicFullName.Equals(music.MusicFullName)).FirstOrDefault();

            if(musics != null)
                return null;

            try
            {
                _context.FavoriteMusic.Add(music);
                _context.SaveChanges();
                return 1;
            }
            catch(Exception)
            {
                return 0;
            }
        }

        public List<Music> GetAllMusic()
        {
            return _context.FavoriteMusic.ToList();
        }

        public Music GetMusicById(int id)
        {
            return _context.FavoriteMusic.Where(x=> x.MusicId.Equals(id)).FirstOrDefault();
        }

        public int? RemoveMusicById(int id)
        {
            var music = this.GetMusicById(id);
            if(music == null)
                return null;
            try
            {
                _context.FavoriteMusic.Remove(music);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
            
        }

        public int? UpdateMusic(Music music)
        {
            var musicUpdate = this.GetMusicById(music.MusicId);
            if(musicUpdate == null)
                return null;

            musicUpdate.MusicFullName = music.MusicFullName;
            musicUpdate.AverageLengthOfSong = music.AverageLengthOfSong;
            musicUpdate.GenreName = music.GenreName;
            musicUpdate.Instrument = music.Instrument;

            try
            {
                _context.FavoriteMusic.Update(musicUpdate);
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