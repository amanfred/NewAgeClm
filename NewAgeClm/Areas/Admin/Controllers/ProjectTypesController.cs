using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewAgeClm.Data;
using NewAgeClm.Models;

namespace NewAgeClm.Areas.Admin.Controllers
{
	[Area("Admin")]
    public class ProjectTypesController : Controller
    {
		private readonly ApplicationDbContext db; //dependency injection

		public ProjectTypesController(ApplicationDbContext db)
		{
			this.db = db;
		}

        public IActionResult Index()
        {
            return View(db.ProjectTypes.ToList());			
        }

		//GET Create
		public IActionResult Create()
		{
			return View();
		}
		//POST Create
		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> Create(ProjectTypes projectTypes)
		{
			if (ModelState.IsValid)
			{
				/*projectTypes.Name = projectTypes.Name.ToLower();
				projectTypes.Name.First().ToString().ToUpper();*/
				db.Add(projectTypes);
				await db.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(projectTypes);
		}

		//GET Edit
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
				return NotFound();
			if (id < 0)
				return NotFound();

			var projectType = await db.ProjectTypes.FindAsync(id);

			if (projectType == null)
				return NotFound();

			return View(projectType);
		}

		//POST Edit action method
		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> Edit(int id, ProjectTypes projectTypes)
		{
			if (projectTypes == null)
				return NotFound();
			if (id != projectTypes.Id)
				return NotFound();

			if (ModelState.IsValid)
			{
				/*projectTypes.Name = projectTypes.Name.ToLower();
				projectTypes.Name.First().ToString().ToUpper();*/

				db.Update(projectTypes);
				//db.Attach(projectTypes);
				await db.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(projectTypes);
		}

		//GET Delete
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
				return NotFound();
			if (id < 0)
				return NotFound();

			var projectType = await db.ProjectTypes.FindAsync(id);

			if (projectType == null)
				return NotFound();

			return View(projectType);
		}

		//POST Delete action method
		[HttpPost, ActionName("Delete")]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> DeleteProjectType(int id)
		{
			var projectType = await db.ProjectTypes.FindAsync(id);
			if (projectType == null)
				return NotFound();

			db.Remove(projectType);
			//db.Attach(projectTypes);
			await db.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}