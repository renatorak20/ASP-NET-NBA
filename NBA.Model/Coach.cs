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

        [Required]
        [MinLength(3, ErrorMessage = "Enter at least 3 characters")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Enter at least 3 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }

		[ForeignKey(nameof(Country))]
		public int? CountryID { get; set; }
		public Country? Country { get; set; }

		[ForeignKey(nameof(Team))]
		public int? TeamID { get; set; }
		public Team? Team { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public int? GetAge()
		{
			var today = DateTime.Today;
			var age = today.Year - DateOfBirth.Year;
			return age;
		}

	}
}
