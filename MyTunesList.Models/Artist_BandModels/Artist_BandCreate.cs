using MyTunesList.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Models
{
    public class Artist_BandCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int FormationYear { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Genre Genre { get; set; }
    }
}
