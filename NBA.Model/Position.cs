﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.Model
{
	public class Position
	{
		[Key]
		public int ID { get; set; }
		public string Name { get; set; }

		public virtual ICollection<Player> Players { get; set;}
	}
}
