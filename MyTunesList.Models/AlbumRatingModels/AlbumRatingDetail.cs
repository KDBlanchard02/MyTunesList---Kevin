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
    public class AlbumRatingDetail
    {
        [Key]
        public int AlbumRatingId { get; set; }

        
        [ForeignKey(nameof(Album))]
        public int AlbumId { get; set; }
        private Album Album { get; set; }       
        public string AlbumTitle { get; set; }
        public string AlbumArtist { get; set; }


        public Guid AuthorId { get; set; }

        public double Rating { get; set; }
        public string ReviewComment { get; set; }
        

        [Display(Name = "Created")]
        public DateTimeOffset DateCreated { get; set; }

        [Display(Name = "Edited")]
        public DateTimeOffset? DateModified { get; set; }

    }
}
