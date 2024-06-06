using System.ComponentModel.DataAnnotations;

namespace NBA.Model
{
	public class Venue
	{
		[Key]
		public int ID { get; set; }
		public string Name { get; set; }
		public string City { get; set; }
		public virtual ICollection<Team> Teams { get; set; }
	}
}
