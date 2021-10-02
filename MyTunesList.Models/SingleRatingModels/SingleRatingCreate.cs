using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Models
{
    public class SingleRatingCreate
    {
        [Required]
        public double Rating { get; set; }

        [Required]
        [MaxLength(3000)]
        public string ReviewComment { get; set; }

        [Required]
        public int SingleId { get; set; }
    }
}
