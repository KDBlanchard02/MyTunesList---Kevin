using MyTunesList.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Models
{
    public class SingleCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least 1 character.")]
        [MaxLength(1000, ErrorMessage = "There are too many characters in this field. (Max: 1,000)")]
        public string Title { get; set; }
        [Required]
        public Genre Genre { get; set; }

        [Required]
        public string Artist_Band { get; set; }
        [Display(Name = "Date Released")]
        [Required]
        public int ReleaseDate { get; set; }
    }
}

