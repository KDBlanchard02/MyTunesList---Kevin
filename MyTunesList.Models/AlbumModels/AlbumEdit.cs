using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Models
{
    public class AlbumEdit
    {
        public int AlbumId { get; set; }
        public string Artist { get; set; }
        public string AlbumTitle { get; set; }
        public string SongList { get; set; }
        public int ReleaseYear { get; set; }
    }
}
