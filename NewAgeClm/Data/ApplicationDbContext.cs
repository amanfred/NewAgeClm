using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewAgeClm.Areas.RegularUser.Models;
using NewAgeClm.Models;

namespace NewAgeClm.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Projects> Projects { get; set; }
		public DbSet<ProjectTypes> ProjectTypes { get; set; }
		public DbSet<Priorities> Priorities { get; set; }
		public DbSet<Labels> Labels { get; set; }
	}
}
