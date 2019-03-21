using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;
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
		private readonly HostingEnvironment hostingEnvironment;

		[BindProperty]
		public ProjectAttributesViewModel ProjectAttributesVM { get; set; }

		public ProjectController(ApplicationDbContext db)
		{
			this.db = db;
			ProjectAttributesVM = new ProjectAttributesViewModel
			{
				ProjectTypes = db.ProjectTypes.ToList(),
				Statuses = db.Statuses.ToList(),
				Priorities = db.Priorities.ToList(),
				Labels = db.Labels.ToList(),
				Categories = db.Categories.ToList(),
				Projects = new Models.Projects()
			};
		}

		public async Task<IActionResult> Index()
		{
			var projects = await db.Projects.
				Include(m => m.ProjectTypes).
				Include(m => m.Statuses).
				Include(m => m.Priorities).
				Include(m => m.Categories).
				Include(m => m.Labels).
				ToListAsync();
			return View(projects);
		}

		// GET: Status/Create
		public IActionResult Create()
		{
			return View(ProjectAttributesVM);
		}
		
		// POST: Status/Create
		[HttpPost, ActionName("Create")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateProject()
		{
			try
			{
				if (ModelState.IsValid)
				{
					ProjectAttributesVM.Projects.Key.ToUpper();
					
					db.Add(ProjectAttributesVM.Projects);
					await db.SaveChangesAsync();

					//Saving Image
					//root path
					/*string webRootPath = hostingEnvironment.WebRootPath;
					//rename the image to projects id
					var files = HttpContext.Request.Form.Files;
					var projectsFromDb = db.Projects.Find(ProjectAttributesVM.Projects.Id);

					if(files.Count > 0)
					{
						//file (image) has been uploaded
						//find the path of upload
						var upload = Path.Combine(webRootPath, StaticData.ImageFolder); //exact loacation
																						//find extension
						var extension = Path.GetExtension(files[0].FileName);
						using (var fileStream = new FileStream(Path.Combine(upload, ProjectAttributesVM.Projects.Id + extension), FileMode.Create))
						{
							files[0].CopyTo(fileStream);
						}

						projectsFromDb.Image = @"\" + StaticData.ImageFolder + @"\" + ProjectAttributesVM.Projects.Id + extension;
					}
					else
					{
						//dummy image or do nothing...
					}
					*/
					await db.SaveChangesAsync();
					//return RedirectToAction("Index", "Project", new { area = "RegularUser" });
					return RedirectToAction(nameof(Index));
				}
				return View(ProjectAttributesVM);
			}
			catch (Exception e)
			{
				return View(e.InnerException.Message);
			}
		}

		// GET: Status/Create
		public async Task<IActionResult> Edit(int? id)
		{

			if (id == null)
				return NotFound();
			if (id < 0)
				return NotFound();

			//	var project = await db.Projects.FindAsync(id);
			ProjectAttributesVM.Projects = await db.Projects.
				Include(m => m.ProjectTypes).
				Include(m => m.Statuses).
				Include(m => m.Priorities).
				Include(m => m.Categories).
				Include(m => m.Labels).
				SingleOrDefaultAsync(m => m.Id == id);
			if (ProjectAttributesVM.Projects == null)
				return NotFound();

			//return View(label);
			return View(ProjectAttributesVM);
		}


	}
}