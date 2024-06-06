using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NBA.Model
{
	public class Attachment
	{
		[Key]
		public int ID { get; set; }

		[ForeignKey(nameof(Coach))]
		public int CoachID { get; set; }
		public Coach Coach { get; set; }

		public string Path { get; set; }
	}
}
