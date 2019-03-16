using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewAgeClm.Data;
using NewAgeClm.Models;

namespace NewAgeClm.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class StatusesController : Controller
    {
		private readonly ApplicationDbContext db; //dependency injection

		public StatusesController(ApplicationDbContext db)
		{
			this.db = db;	
		}

		// GET: Status
		public IActionResult Index()
        {
            return View(db.Statuses.ToList());
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
        public async Task<IActionResult> Create(Statuses statuses)
        {
            try
            {
				if (ModelState.IsValid)
				{
					/*projectTypes.Name = projectTypes.Name.ToLower();
					projectTypes.Name.First().ToString().ToUpper();*/
					db.Add(statuses);
					await db.SaveChangesAsync();
					return RedirectToAction(nameof(Index));
				}
				return View(statuses);
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

			var status = await db.Statuses.FindAsync(id);

			if (status == null)
				return NotFound();

			return View(status);
		}

        // POST: Status/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Statuses statuses)
        {
            try
            {
				if (statuses == null)
					return NotFound();
				if (id != statuses.Id)
					return NotFound();

				if (ModelState.IsValid)
				{
					/*projectTypes.Name = projectTypes.Name.ToLower();
					projectTypes.Name.First().ToString().ToUpper();*/

					db.Update(statuses);
					//db.Attach(projectTypes);
					await db.SaveChangesAsync();
					return RedirectToAction(nameof(Index));
				}
				return View(statuses);
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

			var status = await db.Statuses.FindAsync(id);

			if (status == null)
				return NotFound();

			return View(status);
		}

		// POST: Status/Delete/5
		[HttpPost, ActionName("Delete")]
		[AutoValidateAntiforgeryToken]
		public async Task<IActionResult> DeleteStatus(int id)
		{
            try
            {
				var status = await db.Statuses.FindAsync(id);
				if (status == null)
					return NotFound();

				db.Remove(status);
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