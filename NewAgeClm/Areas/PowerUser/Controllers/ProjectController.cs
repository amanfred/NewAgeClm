using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewAgeClm.Data;

namespace NewAgeClm.Areas.PowerUser.Controllers
{
	[Area("PowerUser")]
    public class ProjectController : Controller
    {
		private readonly ApplicationDbContext db; //dependency injection

		public ProjectController(ApplicationDbContext db)
		{
			this.db = db;
		}

		public IActionResult Index()
        {
            return View(db.Projects.ToList());
        }


    }
}