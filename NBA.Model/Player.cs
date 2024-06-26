﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace NBA.Model
{
	public class Player
	{
		[Key]
		public int ID { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Enter at least 3 characters")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Enter at least 3 characters")]
        public string LastName { get; set; }

		[ForeignKey(nameof(Position))]
		[Required(ErrorMessage = "Position must be selected!")]
		public int? PositionID { get; set; }
		public Position? Position { get; set; }

		[Required(ErrorMessage = "Date of birth is required")]
		public DateTime? DateOfBirth { get; set; }

		[ForeignKey(nameof(Country))]
		[Required(ErrorMessage = "Country must be selected!")]
		public int? CountryID { get; set; }
		public Country? Country { get; set; }

		[ForeignKey(nameof(Team))]
		public int? TeamID { get; set; }
		public Team? Team { get; set; }

		[Range(1, 250, ErrorMessage = "Please enter a number between 1 and 250")]
		public int Height { get; set; }

        [Range(1, 200, ErrorMessage = "Please enter a number between 1 and 200")]
        public int Weight { get; set; }
		public string FullName => $"{FirstName} {LastName}";

        public int? GetAge()
		{
			var today = DateTime.Today;
			if (DateOfBirth == null)
			{
				return 0;
			}
			var age = today.Year - DateOfBirth.Value.Year;
			return age;
		}
	}
}
