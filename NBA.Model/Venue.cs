using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBA.Model
{
	public class Venue
	{
		[Key]
		public int ID { get; set; }
		public string Name { get; set; }

		[ForeignKey(nameof(City))]
		public int? CityID { get; set; }
		public City? City { get; set; }
	}
}
