using MyTunesList.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Models
{
    public class AlbumRatingListItem
    {
        public int AlbumRatingId { get; set; }
        public Guid AuthorId { get; set; }
        public double Rating { get; set; }
        public string ReviewComment { get; set; }


        [ForeignKey(nameof(Album))]
        private int AlbumId { get; set; }
        public string AlbumTitle { get; set; }
        public string ArtistName { get; set; }


        [Display(Name = "Created")]
        public DateTimeOffset DateCreated { get; set; }

        [Display(Name = "Edited")]
        public DateTimeOffset? DateModified { get; set; }
    }
}
