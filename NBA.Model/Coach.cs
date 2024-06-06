﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
		public string Nationality { get; set; }

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