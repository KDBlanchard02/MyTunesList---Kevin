using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Data
{
    public class AlbumRating
    {
        [Key]
        public int AlbumRatingId { get; set; }

        [Required]
        public Guid AuthorId { get; set; }


        [ForeignKey(nameof(Album))]
        public int AlbumId { get; set; }
        public virtual Album Album { get; set; }

        [Required]
        public double Rating { get; set; }

        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateModified { get; set; }

        public string ReviewComment { get; set; }
    }
}
