using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewAgeClm.Models
{
	public class Categories
	{
		public int Id { get; set; }
		public int CodeId { get; set; }

		[Required]
		[StringLength(200, MinimumLength =5)]
		public string Name { get; set; }

	}
}
