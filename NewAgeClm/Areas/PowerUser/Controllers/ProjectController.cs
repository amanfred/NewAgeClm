using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using NewAgeClm.Data;
using NewAgeClm.Models;
using NewAgeClm.Models.ViewModel;
using NewAgeClm.Utility;

namespace NewAgeClm.Areas.PowerUser.Controllers
{
	[Area("PowerUser")]
    public class ProjectController : Controller
    {
		private readonly ApplicationDbContext db; //dependency injection
		private readonly HostingEnvironment hostingEnvironment;

		[BindProperty]
		public ProjectAttributesViewModel ProjectAttributesVM { get; set; }

		public ProjectController(ApplicationDbContext db, HostingEnvironment he)
		{
			this.db = db;
			this.hostingEnvironment = he;
			ProjectAttributesVM = new ProjectAttributesViewModel
			{
				ProjectTypes = db.ProjectTypes.ToList(),
				Statuses = db.Statuses.ToList(),
				Priorities = db.Priorities.ToList()
			};
		}
/*
		public IActionResult Index()
        {
            return View(db.Projects.ToList());
        }
		*/
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
					db.Add(ProjectAttributesVM.Projects);
					await db.SaveChangesAsync();

					//Saving Image
					//root path
					string webRootPath = hostingEnvironment.WebRootPath;
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

					await db.SaveChangesAsync();
					return RedirectToAction("Index", "Project", new { area = "RegularUser" });
				}
				return View(ProjectAttributesVM);
			}
			catch
			{
				return View();
			}
		}

		

	}
}