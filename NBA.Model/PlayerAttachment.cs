using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NBA.Model
{
	public class PlayerAttachment
	{
		[Key]
		public int ID { get; set; }

		[ForeignKey(nameof(Player))]
		public int PlayerID { get; set; }
		public Player Player { get; set; }

		public string Path { get; set; }
	}
}
