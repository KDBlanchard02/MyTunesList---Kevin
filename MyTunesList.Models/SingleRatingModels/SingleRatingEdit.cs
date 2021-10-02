using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Models
{
    public class SingleRatingEdit
    {
        public int SingleRatingId { get; set; }
        public double Rating { get; set; }
        public string ReviewComment { get; set; }
        public DateTimeOffset DateModified { get; set; }
    }
}
