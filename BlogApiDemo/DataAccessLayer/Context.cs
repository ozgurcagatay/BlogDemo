using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.DataAccessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=OZGURCAGATAY;database=CoreBlogApiDb; integrated security=true;");
        }
        public DbSet<Employee> Employees{ get; set; }
        public DbSet<Task> tasks{ get; set; }
    }
}
