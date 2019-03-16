﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace NewAgeClm.Models.ViewModel
{
	public class ProjectAttributesViewModel
	{
		public Projects Projects { get; set; }

		[DisplayName("Project Types")]
		public IEnumerable<ProjectTypes> ProjectTypes { get; set; }
		public IEnumerable<Statuses> Statuses { get; set; }
	}
}
