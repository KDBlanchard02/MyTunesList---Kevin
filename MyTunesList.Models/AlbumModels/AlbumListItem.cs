using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Models
{
    public class AlbumListItem
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public int ReleaseYear { get; set; }
    }
}
