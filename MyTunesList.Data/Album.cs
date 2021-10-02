using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Data
{
    [Table("Album")]
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        [Required]
        public string AlbumTitle { get; set; }

        [Required]
        public int ReleaseYear { get; set; }
        
        [Required]
        public Guid AuthorId { get; set; }
        
        [Required]
        public string Artist_Band { get; set; }

        public string SongList { get; set; }

        public virtual List<AlbumRating> Ratings { get; set; } = new List<AlbumRating>();

        [Range(0, 5)]
        public double AverageRating
        {
            get
            {
                double totalAverageRating = 0;
                foreach (var rating in Ratings)
                {
                    totalAverageRating += rating.Rating;
                }
                return Ratings.Count > 0
                    ? Math.Round(totalAverageRating / Ratings.Count, 2) // if Ratings.Count > 0
                    : 0; // if Ratings.Count not > 0
            }
        }

    }
}
