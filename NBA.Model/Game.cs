using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.Model
{
    public class Game
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(Team))]
        public int? TeamHomeID { get; set; }
        public Team? TeamHome { get; set; }

        [ForeignKey(nameof(Team))]
        public int? TeamAwayID { get; set; }
        public Team? TeamAway { get; set; }

        [ForeignKey(nameof(Venue))]
        public int? VenueID { get; set; }
        public Venue? Venue { get; set; }

        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public DateTime? DateOfGame { get; set; }
    }
}
