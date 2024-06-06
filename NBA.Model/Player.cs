﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace NBA.Model
{
	public class Player
	{
		[Key]
		public int ID { get; set; }

		[StringLength(30, ErrorMessage = "Maximum length allowed is 30 characters")]
		public string FirstName { get; set; }

		[StringLength(30, ErrorMessage = "Maximum length allowed is 30 characters")]
		public string LastName { get; set; }

		[ForeignKey(nameof(Position))]
		public int? PositionID { get; set; }
		public Position? Position { get; set; }
		public DateTime? DateOfBirth { get; set; }

		[ForeignKey(nameof(Country))]
		public int? CountryID { get; set; }
		public Country? Country { get; set; }

		[ForeignKey(nameof(Team))]
		public int? TeamID { get; set; }
		public Team? Team { get; set; }

		public double Height { get; set; }
		public double Weight { get; set; }
		public string FullName => $"{FirstName} {LastName}";
		public virtual ICollection<PlayerAttachment>? Attachments { get; set; }

		public int? GetAge()
		{
			if (!DateOfBirth.HasValue)
				return null;

			var today = DateTime.Today;
			var age = today.Year - DateOfBirth.Value.Year;
			if (DateOfBirth.Value.Date > today.AddYears(-age)) age--;
			return age;
		}
	}
}
