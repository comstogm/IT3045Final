using System;
using System.ComponentModel.DataAnnotations;

namespace Comstock_Gabriel_Final.Models
{
    public class Music
    {
        [Key]
        public int MusicId { get; set; }

        public string MusicFullName { get; set; }

        public string GenreName { get; set; }

        public string Instrument { get; set; }
        public int AverageLengthOfSong {get; set; }
    }
}