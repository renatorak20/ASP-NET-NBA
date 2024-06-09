using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.Model
{
    public class Conference
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
		public virtual ICollection<Team> Teams { get; set; }
	}
}
