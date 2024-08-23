using Microsoft.EntityFrameworkCore;

namespace pra_test.Data
{
    public class DbContextData:DbContext
    {
        public DbContextData(DbContextOptions<DbContextData> options) : base(options)
        {

        }

        public DbSet<Person> persons  { get; set; }
    }
}
