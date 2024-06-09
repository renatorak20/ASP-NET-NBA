using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NBA.Model
{
	public class Team
	{
		[Key]
		public int ID { get; set; }
		public string Name { get; set; }

		[ForeignKey(nameof(Venue))]
		public int? VenueID { get; set; }
		public Venue? Venue { get; set; }

        [ForeignKey(nameof(Conference))]
        public int? ConferenceID { get; set; }
        public Conference? Conference { get; set; }

		[ForeignKey(nameof(TeamAttachment))]
        public int? TeamAttachmentID { get; set; }
        public TeamAttachment TeamAttachment { get; set; }
		public virtual ICollection<Player>? Players { get; set; }
	}
}
