using Microsoft.EntityFrameworkCore;

namespace CompanyT.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();   // удаляем бд со старой схемой
            //Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Notes> Notes { get; set; } = null !;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<History> Historys { get; set; } = null!;
    }
}
