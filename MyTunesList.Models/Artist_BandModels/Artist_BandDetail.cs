using MyTunesList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Models
{
    public class Artist_BandDetail
    {
        public int Artist_BandId { get; set; }
        public string Name { get; set; }
        public int FormationYear { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
    }
}
