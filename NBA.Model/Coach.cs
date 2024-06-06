using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.Model
{
	public class Coach
	{
		[Key]
		public int ID { get; set; }

		[StringLength(30, ErrorMessage = "Maximum length allowed is 30 characters")]
		public string FirstName { get; set; }

		[StringLength(30, ErrorMessage = "Maximum length allowed is 30 characters")]
		public string LastName { get; set; }
		public DateTime? DateOfBirth { get; set; }

		[ForeignKey(nameof(Country))]
		public int? CountryID { get; set; }
		public Country? Country { get; set; }

		[ForeignKey(nameof(Team))]
		public int? TeamID { get; set; }
		public Team? Team { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public int? GetAge()
		{
			if (!DateOfBirth.HasValue)
				return null;

			var today = DateTime.Today;
			var age = today.Year - DateOfBirth.Value.Year;
			return age;
		}

	}
}
