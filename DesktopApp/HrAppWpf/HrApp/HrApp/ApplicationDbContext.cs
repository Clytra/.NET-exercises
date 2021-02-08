using HrApp.Models.Configurations;
using HrApp.Models.Domains;
using HrApp.Models.Wrappers;
using System.Data.Entity;

namespace HrApp
{
    class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base(ServerWrapper.GetConnectionString()) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Filter> Filters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new FilterConfiguration());
        }
    }
}
