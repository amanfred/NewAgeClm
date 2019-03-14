using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewAgeClm.Data;

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
    }
}