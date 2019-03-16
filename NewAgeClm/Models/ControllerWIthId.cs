using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewAgeClm.Models
{
	public class ControllerWIthId
	{
		public int Id { get; set; }
		public string ControllerName { get; set; }
		public bool ShowDetails { get; set; }

		public ControllerWIthId()
		{
			ShowDetails = false;
		}
		
	}
}
