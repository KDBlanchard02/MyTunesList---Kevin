using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Models
{
    public class AlbumRatingEdit
    {
        public int AlbumRatingId { get; set; }
        public double Rating { get; set; }
        public string ReviewComment { get; set; }
        public DateTimeOffset DateModified { get; set; }
    }
}
