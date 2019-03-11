using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewAgeClm.Areas.RegularUser.Models
{
	public class ProjectTypes
	{
		[Required]
		public int Id { get; set; }

		[Required, StringLength(20, MinimumLength =2)]
		public string Name { get; set; }
	}
}
