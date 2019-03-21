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
    public class LabelsController : Controller
    {
		private readonly ApplicationDbContext db;

		public LabelsController(ApplicationDbContext db)
		{
			this.db = db;
		}

		// GET: Status
		public IActionResult Index()
		{
			return View(db.Labels.ToList());
		}
		
		// GET: Status/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Status/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Labels labels)
		{
			try
			{
				if (ModelState.IsValid)
				{
					/*projectTypes.Name = projectTypes.Name.ToLower();
					projectTypes.Name.First().ToString().ToUpper();*/
					db.Add(labels);
					await db.SaveChangesAsync();
					return RedirectToAction(nameof(Index));
				}
				return View(labels);
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

			var label = await db.Labels.FindAsync(id);

			if (label == null)
				return NotFound();

			return View(label);
		}

		// POST: Status/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, Labels labels)
		{
			try
			{
				if (labels == null)
					return NotFound();
				if (id != labels.Id)
					return NotFound();

				if (ModelState.IsValid)
				{
					/*projectTypes.Name = projectTypes.Name.ToLower();
					projectTypes.Name.First().ToString().ToUpper();*/

					db.Update(labels);
					//db.Attach(projectTypes);
					await db.SaveChangesAsync();
					return RedirectToAction(nameof(Index));
				}
				return View(labels);
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

			var labels = await db.Labels.FindAsync(id);

			if (labels == null)
				return NotFound();

			return View(labels);
		}

		// POST: Status/Delete/5
		[HttpPost, ActionName("Delete")]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> DeleteLabels(int id)
		{
			try
			{
				var label = await db.Labels.FindAsync(id);
				if (label == null)
					return NotFound();

				db.Remove(label);
				//db.Attach(projectTypes);
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