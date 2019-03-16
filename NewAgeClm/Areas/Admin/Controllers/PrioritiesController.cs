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
    public class PrioritiesController : Controller
    {
		private readonly ApplicationDbContext db; //dependency injection

		public PrioritiesController(ApplicationDbContext db)
		{
			this.db = db;
		}

		// GET: Status
		public IActionResult Index()
		{
			return View(db.Priorities.ToList());
		}

		// GET: Status/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: Status/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Status/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Priorities priority)
		{
			try
			{
				if (ModelState.IsValid)
				{
					/*projectTypes.Name = projectTypes.Name.ToLower();
					projectTypes.Name.First().ToString().ToUpper();*/
					db.Add(priority);
					await db.SaveChangesAsync();
					return RedirectToAction(nameof(Index));
				}
				return View(priority);
			}
			catch
			{
				return View();
			}
		}

		// GET: Status/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
				return NotFound();
			if (id < 0)
				return NotFound();

			var priority = await db.Priorities.FindAsync(id);

			if (priority == null)
				return NotFound();

			return View(priority);
		}

		// POST: Status/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, Priorities priority)
		{
			try
			{
				if (priority == null)
					return NotFound();
				if (id != priority.Id)
					return NotFound();

				if (ModelState.IsValid)
				{
					/*projectTypes.Name = projectTypes.Name.ToLower();
					projectTypes.Name.First().ToString().ToUpper();*/

					db.Update(priority);
					//db.Attach(projectTypes);
					await db.SaveChangesAsync();
					return RedirectToAction(nameof(Index));
				}
				return View(priority);
			}
			catch
			{
				return View();
			}
		}

		// GET: Status/Delete/5		
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
				return NotFound();
			if (id < 0)
				return NotFound();

			var priority = await db.Priorities.FindAsync(id);

			if (priority == null)
				return NotFound();

			return View(priority);
		}

		// POST: Status/Delete/5
		[HttpPost, ActionName("Delete")]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> DeletePriority(int id)
		{
			try
			{
				var priority = await db.Priorities.FindAsync(id);
				if (priority == null)
					return NotFound();

				db.Remove(priority);				
				await db.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}