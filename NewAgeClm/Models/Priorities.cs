using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewAgeClm.Models
{
	public class Priorities
	{
		[Required]
		public int Id { get; set; }

		[Required]
		public int Code { get; set; }

		[Required, StringLength(20, MinimumLength = 2)]
		public string Name { get; set; }
	}
}
