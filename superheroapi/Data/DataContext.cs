using superheroapi.Models;

namespace superheroapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=e-learningdb;Trusted_Connection=true;TrustServerCertificate=true;");
            optionsBuilder.UseSqlServer("server=.\\MSSQLSERVER2019;database=e-learndb;User ID=e-learnadmin;password=#051n3krW;MultipleActiveResultSets=True;encrypt=false;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
