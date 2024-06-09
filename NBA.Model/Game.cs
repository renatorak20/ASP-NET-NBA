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
		[Required(ErrorMessage = "Home team must be selected!")]
		public int? TeamHomeID { get; set; }
        public Team? TeamHome { get; set; }

        [ForeignKey(nameof(Team))]
		[Required(ErrorMessage = "Away team must be selected!")]
		public int? TeamAwayID { get; set; }
        public Team? TeamAway { get; set; }

        [ForeignKey(nameof(Venue))]
		[Required(ErrorMessage = "Game venue must be selected!")]
		public int? VenueID { get; set; }
        public Venue? Venue { get; set; }


        [Required]
        [Range(1, 1000, ErrorMessage = "Please enter a number between 1 and 1000")]
        public int HomeScore { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Please enter a number between 1 and 1000")]
        public int AwayScore { get; set; }

        [Required(ErrorMessage = "Date of game is required")]
        public DateTime? DateOfGame { get; set; }
    }
}
