using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewAgeClm.Data;
using NewAgeClm.Models;
using NewAgeClm.Models.ViewModel;

namespace NewAgeClm.Areas.Admin.Controllers
{
	[Area("Admin")]
    public class ProjectAttributesController : Controller
    {
		private readonly ApplicationDbContext db;

		//[BindProperty]
		public  ProjectAttributesViewModel ProjectAttributesVM { get; set; }

		public ProjectAttributesController(ApplicationDbContext db)
		{
			this.db = db;
			ProjectAttributesVM = new ProjectAttributesViewModel
			{
				ProjectTypes = db.ProjectTypes.ToList(),
				Statuses = db.Statuses.ToList(),
				Priorities = db.Priorities.ToList(),
				Labels = db.Labels.ToList(),
				Categories = db.Categories.ToList(),
				Projects = new Projects()
			};
		

		}

        public IActionResult Index()
        {
			
            return View(ProjectAttributesVM);
        }	
	}
}