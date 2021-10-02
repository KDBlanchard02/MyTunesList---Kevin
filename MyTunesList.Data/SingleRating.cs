using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Data
{
    public class SingleRating
    {
        [Key]
        public int SingleRatingId { get; set; }

        [ForeignKey(nameof(SingleTrack))]
        public int SingleId { get; set; }

        public virtual SingleTrack SingleTrack { get; set; }

        [Required, Range(0, 5)]
        public double Rating { get; set; }

        [Required]
        public DateTimeOffset DateCreated { get; set; }

        public DateTimeOffset? DateModified { get; set; }

        [Required]
        public string ReviewComment { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

    }
}
