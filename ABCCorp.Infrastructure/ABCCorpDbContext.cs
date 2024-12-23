using System;
using Microsoft.EntityFrameworkCore;

namespace ABCCorp.Infrastructure
{
	public class ABCCorpDbContext: DbContext
	{
		public ABCCorpDbContext(DbContextOptions<ABCCorpDbContext> options) : base(options)
		{
		}

        public virtual DbSet<Domain.Models.Task> Task { get; set; }
        public virtual DbSet<Domain.Models.Employee> Employee { get; set; }
        public virtual DbSet<Domain.Models.Employee_Task> Employee_Task { get; set; }



    }
}

