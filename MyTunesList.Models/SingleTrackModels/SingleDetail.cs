using MyTunesList.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Models
{
    public class SingleDetail
    {
        public int SingleId { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public string Artist_Band { get; set; }
        [Display(Name = "Date Released")]
        public int ReleaseDate { get; set; }
        public double AverageRating { get; set; }

    }
}
