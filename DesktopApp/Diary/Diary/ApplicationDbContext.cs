using System.Data.Entity;

namespace Diary
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }

    }
}