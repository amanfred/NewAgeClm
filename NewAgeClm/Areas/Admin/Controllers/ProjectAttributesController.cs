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
				Statuses = db.Statuses.ToList()
			};
		

		}

        public IActionResult Index()
        {
			
            return View(ProjectAttributesVM);
        }

		//GET
		public IActionResult Create()
		{
			return View();
		}

		//POST
		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> Create(ProjectTypes projectTypes)
		{
			if(ModelState.IsValid)
			{
				/*projectTypes.Name = projectTypes.Name.ToLower();
				projectTypes.Name.First().ToString().ToUpper();*/
				db.Add(projectTypes);
				await db.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(projectTypes);
		}
    }
}