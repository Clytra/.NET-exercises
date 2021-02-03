using System.Data.Entity;

namespace HrApp
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=ApplicationDbContext") { }
    }
}
