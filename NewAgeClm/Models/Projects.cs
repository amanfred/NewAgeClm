using NewAgeClm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace NewAgeClm.Areas.RegularUser.Models
{
	public class Projects
	{
		public int Id { get; set; }

		[Required, StringLength(200, MinimumLength =5)]
		public string Name { get; set; }

		public string Description { get; set; }

		[Display(Name = "Type")]
		public int ProjectTypeId { get; set; }

		[ForeignKey("ProjectTypeId")]
		public virtual ProjectTypes ProjectTypes { get; set; } //If "virtual" keyword is provided, this will not be added to the database

		[Display(Name = "Priority")]
		public int PriorityId { get; set; }

		[ForeignKey("PriorityId")]
		public virtual Priorities Priorities { get; set; } //If "virtual" keyword is provided, this will not be added to the database
	}
}
