using MyTunesList.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTunesList.Models
{
    public class SingleRatingListItem
    {
        public int SingleRatingId { get; set; }

        [ForeignKey(nameof(SingleTrack))]
        public int SingleId { get; set; }
        private SingleTrack SingleTrack { get; set; }
        public string SingleTrackTitle { get; set; }

        public double Rating { get; set; }

        public string ReviewComment { get; set; }

        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateModified { get; set; }
    }
}
