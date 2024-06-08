using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NBA.Model
{
	public class TeamAttachment
	{
		[Key]
		public int ID { get; set; }

		public string Path { get; set; }
    }
}
