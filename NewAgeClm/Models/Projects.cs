using NewAgeClm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace NewAgeClm.Models
{
	public class Projects
	{
		public int Id { get; set; }

		[Required, StringLength(200, MinimumLength =5)]
		[Display(Name="Project")]
		public string Name { get; set; }

		public string Description { get; set; }

		public int ProjectTypeId { get; set; }

		[ForeignKey("ProjectTypeId")]
		[Display(Name = "Type")]
		public virtual ProjectTypes ProjectTypes { get; set; } //If "virtual" keyword is provided, this will not be added to the database

		[Display(Name = "Priority")]
		public int PriorityId { get; set; }

		[ForeignKey("PriorityId")]
		public virtual Priorities Priorities { get; set; } 

		[Required]
		public string Reporter { get; set; }

		public string Assignee { get; set; }

		[Display(Name = "Labels")]
		public int LabelId { get; set; }

		[ForeignKey("LabelId")]
		public virtual Labels Labels { get; set; } 

		[Display(Name = "Status")]
		public int StatusId { get; set; }

		[ForeignKey("StatusId")]
		[Display(Name = "Status")]
		public virtual Statuses Statuses { get; set; } 

		[StringLength(3, MinimumLength = 3)]
	//	[RegularExpression(@"/^[A-Za-z]+$/")]
		public string Key { get; set; }

		[Display(Name = "Lead")]
		public string ProjectLead { get; set; }

		public int CategoryId { get; set; }

		[ForeignKey("CategoryId")]
		[Display(Name = "Category")]
		public virtual Categories Categories { get; set; }

		//public string Image { get; set; }


	}
}
