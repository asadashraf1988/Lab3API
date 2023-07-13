using Microsoft.EntityFrameworkCore;

namespace Lab3API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Lab3> Lab3Users { get; set; }
    }
}
