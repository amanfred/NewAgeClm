using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewAgeClm.Data;
using NewAgeClm.Models.ViewModel;

namespace NewAgeClm.Areas.RegularUser.Controllers
{
	[Area("RegularUser")]
	public class ProjectController : Controller
	{
		private readonly ApplicationDbContext db; //dependency injection

		//[BindProperty]
		public ProjectAttributesViewModel ProjectAttributesVM { get; set; }

		public ProjectController(ApplicationDbContext db)
		{
			this.db = db;
			ProjectAttributesVM = new ProjectAttributesViewModel
			{
				ProjectTypes = db.ProjectTypes.ToList(),
				Statuses = db.Statuses.ToList(),
				Priorities = db.Priorities.ToList()
			};
		}

		public async Task<IActionResult> Index()
		{
			var projects = await db.Projects.
				Include(m => m.ProjectTypes).
				Include(m => m.Statuses).
				Include(m => m.Priorities).
				ToListAsync();
			return View(projects);
		}
				
	}
}